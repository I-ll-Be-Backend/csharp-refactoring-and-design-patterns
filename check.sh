#!/bin/sh
# Compiles every step of every lesson in mcr.microsoft.com/dotnet/sdk:8.0: the check each lesson passed before its video went out.
# Needs Docker. A step folder holding .nocheck does not compile on purpose and is skipped.
docker run --rm --entrypoint /bin/sh -v "$PWD:/w" mcr.microsoft.com/dotnet/sdk:8.0 -c '
dotnet new classlib -o /tmp/p --force >/dev/null && rm -f /tmp/p/Class1.cs
cd /w; fail=0
for f in */step-*/*.cs; do
  [ -e "$f" ] || continue
  [ -e "$(dirname "$f")/.nocheck" ] && continue
  d=$(mktemp -d)
  if ( cp $f /tmp/p/Lesson.cs && dotnet build /tmp/p -nologo -v q -clp:NoSummary ) >/tmp/log 2>&1; then echo "ok    $f"; else echo "FAIL  $f"; cat /tmp/log; fail=1; fi
done
exit $fail'
