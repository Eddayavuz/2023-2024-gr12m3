-- returns the number of values in the employees table
SELECT COUNT(*)
FROM employees

-- returns the number of values in the employees table that matches the condition
SELECT COUNT(*) as Seniors
FROM employees
WHERE YearsOfExperience > 10

-- returns the number of values in the employees table that is grouped by the gender
SELECT Gender, COUNT(*) as FemaleEmployees
FROM employees
GROUP BY Gender


--select the sum of salary from employees table to calculate the monthly outcome of this company
SELECT SUM(Salary) AS MonthlyOutcome
FROM employees

--select the sum of salary of the developers from employees table to calculate the monthly pay to Devs
SELECT SUM(Salary) AS MonthlyDevSalaries
FROM employees
WHERE JobTitle LIKE '%Developer%' 

--select the average salary for each person regardles the position and years of experience
SELECT AVG(Salary) AS AVGSalary
FROM employees

--Let's try and analyze this data to figure out if there is a pay gap in this company.

-- first let's select the average salary for each person regardles the position and years of experience
SELECT AVG(Salary) AS AVGSalary
FROM employees

--now select the avg salary for each gender.
SELECT Gender, AVG(Salary) As AvgSalary
FROM employees
GROUP BY Gender

-- let's be optimistic and consider other factors such as years of experience.. Let's check if men has more experience than women.
SELECT Gender, AVG(YearsOfExperience) AS Experience
FROM employees
GROUP BY Gender

-- let's be optimistic for one last time and consider the factor of the job title.

-- select jobs and their average payments
SELECT JobTitle, AVG(Salary) AS Pay
FROM employees
GROUP BY JobTitle
ORDER BY Pay DESC

-- Let's see what is the number of female workers on each department
SELECT Gender,JobTitle, COUNT(JobTitle) As Number
FROM employees
GROUP BY JobTitle, Gender

-- select the employees with the same position and same experience and group them by their gender 
SELECT JobTitle,YearsOfExperience, Gender, Salary
FROM employees
WHERE Gender = 'male' AND YearsOfExperience >= 10 AND JobTitle = 'DevOps Engineer'
ORDER BY YearsOfExperience DESC

SELECT JobTitle,YearsOfExperience, Gender, Salary
FROM employees
WHERE Gender = 'female' AND YearsOfExperience >= 10 AND JobTitle = 'DevOps Engineer'
ORDER BY YearsOfExperience DESC

-- CONCLUSION: As you can see from all the data, this company is A COMPLETELY TRASH COMPANY

-- select the minumum salary by the JobTitle
SELECT JobTitle, MIN(Salary) AS Minimum
FROM employees
GROUP BY JobTitle

-- select the maximum salary by the JobTitle
SELECT JobTitle, MAX(Salary) AS Maximum
FROM employees
GROUP BY JobTitle