DELETE FROM "StatusHistory";
DELETE FROM "Orders";
DELETE FROM "CartItems";
DELETE FROM "ShoppingCarts";
DELETE FROM "Customer";

insert into "Customer" 
values (1000),
       (2000);

insert into "ShoppingCarts" 
values (1000),
       (2000);

insert into "CartItems"
values (1000,
        1,
        1,
        1000,
        1,
        'Polyester',
        100,
        'T-Shirt',
        'M'),
       (2000,
        2,
        1,
         1000,
        1,
        'Polyester',
        100,
        'T-Shirt',
        'S'),
       (3000,
        1,
        1,
        2000,
        1,
        'Polyester',
        100,
        'T-Shirt',
        'M');

insert into "Orders"
values (1000,
        1000,
        1,
        1000),
       (2000,
        2000,
        1,
        2000);


insert into "StatusHistory"
values (1000,
        1000,
        1,
        now()),
       (2000,
        2000,
        1,
        now())
