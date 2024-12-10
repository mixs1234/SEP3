DELETE FROM "StatusHistory";
DELETE FROM "Orders";
DELETE FROM "CartItems";
DELETE FROM "ShoppingCarts";
DELETE FROM "Customer";

insert into "Customer" 
values (1),
       (2);

insert into "ShoppingCarts" 
values (1),
       (2);

insert into "CartItems"
values (1,
        1,
        1,
        1,
        1,
        'Polyester',
        100,
        'T-Shirt',
        'M'),
       (2,
        2,
        1,
         1,
        1,
        'Polyester',
        100,
        'T-Shirt',
        'S'),
       (3,
        1,
        1,
        2,
        1,
        'Polyester',
        100,
        'T-Shirt',
        'M');

insert into "Orders"
values (1,
        1,
        1,
        1),
       (2,
        2,
        1,
        2);


insert into "StatusHistory"
values (1,
        1,
        1,
        now()),
       (2,
        2,
        1,
        now())
