CREATE TABLE products (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL
);

CREATE TABLE categories (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL
);

CREATE TABLE products_categories (
    id INTEGER PRIMARY KEY,
    product_id INTEGER NOT NULL,
    category_id INTEGER NOT NULL,
    FOREIGN KEY (product_id) REFERENCES products (id) ON DELETE CASCADE,
    FOREIGN KEY (category_id) REFERENCES categories (id) ON DELETE CASCADE
);

INSERT INTO products VALUES 
(1, 'Samsumng S21'),
(2, 'Apple Iphone 13'),
(3, 'Nokia 3310'),
(4, 'Motorola razr v3');

INSERT INTO categories VALUES 
(1, 'Smartphone'),
(2, 'Touch screen');

INSERT INTO products_categories VALUES 
(1, 1, 1),
(2, 1, 2),
(3, 2, 1),
(4, 2, 2);

select p.name, c.name from products as p 
left join products_categories as pc on pc.product_id = p.id
left join categories as c on c.id = pc.category_id;