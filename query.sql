SELECT c.FirstName + c.LastName as FullName, 
c.Age, 
o.OrderId, 
o.DateCreated, 
o.MethodofPurchase as PurchaseMethod, 
d.ProductNumber, 
d.ProductOrigin
FROM Customer c
INNER JOIN Orders o on c.PersonId = o.OrderId
INNER JOIN OrderDetails d on o.OrderId = d.OrderId
WHERE d.ProductID = '1112222333'