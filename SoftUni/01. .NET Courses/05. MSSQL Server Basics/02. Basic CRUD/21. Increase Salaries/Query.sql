UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentID IN (SELECT Departments.DepartmentID from Departments WHERE Name in('Engineering', 'Tool Design', 'Marketing', 'Information Services'))
SELECT Salary from Employees
