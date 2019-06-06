Used solutions & technologies


# Solutions

## Stack

* Web/server: .net core / asp.net core / razor views for page generation / swagger for api discovery
* Service: .net core / ef core as ORM / jace.net for formulas / xunit for unit tests
* Deployment: docker

## Database

* Demo deployment uses sqlite as a database for simplicity but there's no database specific code and it can be configured to use something more webscale.
* Equipment is loaded as  EF seed and technically, it's hardcoded, since I haven't implemented create/update methods and auto-scaffolded controllers are not demo-worthy.


### Database schema

* Boilerplate mostly. Soft-deletes, common interfaces for [future] cruds.

* 7 tables:
    * Product. Equipment item.
        * Added image link on top of what was described as a task.
    * ProductCategory.
        * Made pricing more flexible: price for category is a Jace formula that takes duration and user-defined variables from the database.
            For instance, regular equipment price is `OneTime + min(duration, 2) * Premium + max(0, duration - 2) * Regular`.
        * Bonus points are configured per-category / can be reused / are formulas as well(return constants in the demo data but can be configured)
    * Price. Variables for price formula mentioned above.
    * CategoryLoyaltyProgram / LoyaltyProgram.
    * User. Plain user mock.
    * Cart.

## Caching

* The project uses .net's built in distributed cache. Demo deployment is configured to use in-memory provider / it would be redis for production.
* Every API read method is cached.

## UI

Not a big fan of frontend development, so I went with good ol' razor views which can be quickly scaffolded / work out of the box without having to deal with the hot mess of js ecosystem.
If it was a production app, I would've built something with angular but a demo is just not worth it. All required API endpoints are exposed / have swagger configured for them anyway.