DELETE duplicate
FROM (
  SELECT *, rowNumber=row_number() OVER (PARTITION BY CustomerOrderId, ProductId ORDER BY ProductId)
  FROM OrderProduct 
) duplicate
WHERE rowNumber > 1;
ALTER TABLE OrderProduct ADD  CONSTRAINT [IX_UniqueProductId] UNIQUE 
NONCLUSTERED (ProductId ASC, CustomerOrderID ASC)