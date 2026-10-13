# DRY: one rule, one place, in C#

> Change a business rule once and have every feature pick it up.

[Watch the video](https://www.youtube.com/watch?v=J156aSo8YNw) · [Step through it interactively](https://illbebackend.dev/lessons/dry/csharp/)

## The problem

The member limit is added to Checkout and CartBanner by hand. OrderEmail is missed and still uses 50m.

## Steps

Each folder holds the complete `Shipping.cs` after that step, and every one compiles. Diff two neighbouring folders to see a single refactoring.

| Step | What changes | Move |
|---|---|---|
| [01](step-01-three-features-one-rule/) | Three features, one rule: Checkout, CartBanner and OrderEmail each decide on their own whether a cart ships free from 50m. The fee 4.99m is typed twice. | Before |
| [02](step-02-members-ship-free-from-25/) | Members ship free from 25: The member limit is added to Checkout and CartBanner by hand. OrderEmail is missed and still uses 50m. | Code smell |
| [03](step-03-undo-then-give-it-a-home/) | Undo, then give it a home: Back the member change out. Gather the limit, the fee and the check into one static class, then add members again. | Plan |
| [04](step-04-name-the-limit/) | Name the limit: The four copies of 50m become ShippingPolicy.FreeFrom, a const in a new static class. | Extract Constant |
| [05](step-05-name-the-fee/) | Name the fee: The two copies of 4.99m become ShippingPolicy.Fee. | Extract Constant |
| [06](step-06-name-the-check/) | Name the check: The comparison moves into ShippingPolicy.ShipsFree(cart). Checkout calls it. | Extract Method |
| [07](step-07-the-banner-asks-too/) | The banner asks too: CartBanner's hand-written check becomes !ShippingPolicy.ShipsFree(cart). | Replace Inline Code with Method Call |
| [08](step-08-the-email-asks-too/) | The email asks too: OrderEmail calls ShippingPolicy.ShipsFree(cart). The comparison now exists once. | Replace Inline Code with Method Call |
| [09](step-09-name-the-gap/) | Name the gap: The banner's subtraction moves into ShippingPolicy.AmountToFree(cart). | Extract Method |
| [10](step-10-hide-the-limit/) | Hide the limit: FreeFrom becomes private. Code outside ShippingPolicy can't read the limit. | Encapsulate Field |
| [11](step-11-members-in-one-class/) | Members, in one class: The member limit is a new const and a private FreeFromFor(cart) inside ShippingPolicy. Checkout, CartBanner and OrderEmail don't change. | Payoff |

## Takeaways

- **Use it when:** One business rule, number or decision shows up in more than one feature.
- **Skip it when:** Two lines look alike but follow different rules, like a shipping fee and a gift wrap fee that both cost 4.99.
- **Spot it by:** The same literal or condition in several classes, and changes that start with a search.
