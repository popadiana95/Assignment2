//
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddEmployee`(idEmpl int, name varchar(45), title varchar(45))
BEGIN
insert into employee
values(idEmpl, name, title);
END

//
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddOrder`(customerName varchar(45), customerAddress varchar(100), deliverDate date, orderStatus varchar(45))
BEGIN
insert into orders(customer, address, deliverydate, status,total)
values (customerName, customerAddress, deliverDate, orderStatus,0);
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddProduct`(idProduct int, title varchar(45), description varchar(100), color varchar(25), size varchar(25), price float, stock int)
BEGIN
insert into product
values (idProduct, title, description, color, size, price, stock);
END

//
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddProductToOrder`(idOrder int, idProduct int, quantity int)
BEGIN
insert into orderdetails(idOrder, idProduct,quantity)
values( idOrder, idProduct, quantity);
call furniture.UpdateProductPrice;
call furniture.UpdateTotalOrder(idOrder);
call furniture.UpdateStock(idProduct, quantity);
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteEmployee`(idEmpl int)
BEGIN
delete from employee
where employee.idEmployee = idEmpl;
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteOrder`(idOrder int)
BEGIN
Delete from orders
where orders.idOrder = idOrder;
delete from orderdetails
where orderdetails.idOrder = idOrder;
END

//
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteProduct`(idProduct int)
BEGIN
delete from product
where product.idProduct = idProduct;
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertActivity`(idUser int, dataNow datetime, descr varchar(100))
BEGIN
insert into emplactivity
values(idUser,dataNow,descr);
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateEmployee`(idEmpl int, name varchar(45), title varchar(45))
BEGIN
update employee
set employee.name = name,
	employee.title = title
where employee.idEmployee = idEmpl;
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateOrder`(idOrder int, customerName varchar(45), customerAddress varchar(100), deliverDate date, orderStatus varchar(45))
BEGIN
update orders
set orders.customer = customerName, 
	orders.address = customerAddress, 
    orders.deliverydate= deliverDate,
    orders.status = orderStatus
where orders.idOrder = idOrder;
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateOrderDetails`(OrderID int, ProductID int, NewQuantity int)
begin	
       update orderdetails set quantity=NewQuantity 
       where orderdetails.idOrder= OrderID and orderdetails.idProduct = ProductID;
       call furniture.UpdateProductPrice;
       set @IDOrder = OrderID;
       call furniture.UpdateTotalOrder(@IDOrder);
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateProduct`(idProduct int, title varchar(45), description varchar(100), color varchar(25), size varchar(25), price float, stock int)
BEGIN
Update product
set product.title = title,
    product.description = description,
    product.size = size,
    product.color = color,
    product.price = price,
    product.stock = stock
where product.idProduct = idProduct;
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateProductPrice`()
BEGIN
UPDATE orderdetails set priceunit =
(select price from product
	where product.idProduct = orderdetails.idProduct );
update orderdetails set price = quantity * priceunit;
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStock`(idProduct int, quantity int)
BEGIN
set @actualStock = 0;
select @actualStock:= product.stock from product 
where product.idProduct = idProduct;
set @newStock = @actualStock - quantity;
update product 
set product.stock = @newStock
where product.idProduct = idProduct;
END


//
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateTotalOrder`(idOrder int)
BEGIN
SET @SUMA = NULL;
Select @SUMA:= sum(Price)
FRom orderdetails 
where orderdetails.idOrder = idOrder;
update orders set total = @SUMA
where orders.idOrder = idOrder;
END