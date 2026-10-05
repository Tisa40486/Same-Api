INSERT INTO UserDao (
    IsAdmin,
    Age,
    Pseudo,
    Email,
    Password,
    NumberFollowers,
    CreateAt,
    GenderId
) VALUES (
    1,                -- IsAdmin: true (admin user)
    30,               -- Age: example value
    'adminuser',      -- Pseudo: example username
    'admin@example.com', -- Email: example email
    'hashedpassword', -- Password: store hashed password
    0,                -- NumberFollowers: initial value
    GETDATE(),        -- CreateAt: current date/time
    1                 -- GenderId: example gender id
);

INSERT INTO LKP_SameApi_Gender (
    Id,
    Name
) VALUES (
    1,            
    'Male'          
);

INSERT INTO LKP_SameApi_Gender (
    Id,
    Name
) VALUES (
    2,              
    'Female'       
);
