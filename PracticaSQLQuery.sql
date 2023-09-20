SELECT 
    ID,
    LAST_NAME,
    HIRE_DATE,
    SALARY
FROM 
    TEST.EMPLOYEES;
-- Recuperar id, apellido, fecha de contratación, salario de los empleados.


-- Recuperar id, apellido, fecha de contratación, salario anual de los empleados.
-- Tip: Calcular el salario anual como 12 veces el salario. Usar alias para el sueldo anual
SELECT 
    ID,
    LAST_NAME,
    HIRE_DATE,
    SALARY * 12 AS "ANNUAL_SALARY"
FROM 
    TEST.EMPLOYEES;

-- Recuperar id, apellido y nombre, fecha de contratación, salario anual de los empleados.
-- Concatenar usando ||. Notar que los operadores a usar dependen del tipo de dato de los campos. ----> NO PUEDO USAR || USO + PARA CONCATENAR
SELECT
    ID,
    LAST_NAME + ' ' + FIRST_NAME AS "LAST_NAME, FIRST_NAME",
    HIRE_DATE,
    SALARY * 12 AS "ANNUAL_SALARY"
FROM
    TEST.EMPLOYEES;

-- Recuperar apellido y departamento para poder hacer la query anterior.
SELECT 
    LAST_NAME,
	DEPARTMENT_ID
FROM 
    TEST.EMPLOYEES;

-- RECUPERO DEPARTAMENTOS
SELECT 
    DEPARTMENT_NAME
	ID
FROM 
    TEST.DEPARTMENTS;


-- Recuperar lista de departamentos que tienen empleados:
-- a. Recuperar lista de departamentos de los empleados
-- b. Recuperar lista no repetida de departamentos de los empleados
SELECT D.DEPARTMENT_NAME
FROM TEST.DEPARTMENTS D
INNER JOIN TEST.EMPLOYEES E ON D.ID = E.DEPARTMENT_ID;

-- Ahora sin repetir
SELECT DISTINCT D.DEPARTMENT_NAME
FROM TEST.DEPARTMENTS D
INNER JOIN TEST.EMPLOYEES E ON D.ID = E.DEPARTMENT_ID;

-- Recuperar lista de empleados cuyo salario sea menor a 2000.
SELECT ID, FIRST_NAME, LAST_NAME, SALARY
FROM TEST.EMPLOYEES
WHERE SALARY < 2000;

--Recuperar lista de empleados cuyo salario sea entre 1800 y 3000
--Tip: usar cláusula “between”. Notar diferencia con el uso de 2 condiciones.

--SIN BETWEEN
SELECT ID, FIRST_NAME, LAST_NAME, SALARY 
FROM TEST.EMPLOYEES
WHERE SALARY >= 1800 AND SALARY <= 3000;

--CON BETWEEN
SELECT ID, FIRST_NAME, LAST_NAME, SALARY
FROM TEST.EMPLOYEES
WHERE SALARY BETWEEN 1800 AND 3000;


--Recuperar lista de empleados cuyo departamento sea 10 o 30 o 31.
--Tip: usar cláusula “in”.
SELECT ID, FIRST_NAME, LAST_NAME, DEPARTMENT_ID
FROM TEST.EMPLOYEES
WHERE DEPARTMENT_ID IN (10, 30, 31);

--Recuperar lista de empleados cuyo apellido empiece con F.
--Tip: usar cláusula “like”. Notar que los operadores a usar dependen del tipo de dato de los campos.
SELECT ID, FIRST_NAME, LAST_NAME
FROM TEST.EMPLOYEES
WHERE LAST_NAME LIKE 'F%'; --CADENA DE CARACTERES LIKE O = PARA NUMEROS


--Recuperar lista de empleados cuyo job_id:
--a. no hay sido definido
--b. haya sido definido.
--NO DEFINIDO
SELECT ID, FIRST_NAME, LAST_NAME, JOB_ID
FROM [TEST].[EMPLOYEES]
WHERE JOB_ID IS NULL;

--DEFINIDO
SELECT ID, FIRST_NAME, LAST_NAME, JOB_ID
FROM [TEST].[EMPLOYEES]
WHERE JOB_ID IS NOT NULL;


--Recuperar lista de empleados cuyo job_id sea ‘AD_CTB’ o ‘FQ_GRT’ (sin usar IN) y cuyo salario sea mayor a 1900.
--CON PARENTERIS
SELECT ID, FIRST_NAME, LAST_NAME, JOB_ID, SALARY
FROM TEST.EMPLOYEES
WHERE (JOB_ID = 'AD_CTB' OR JOB_ID = 'FQ_GRT') AND SALARY > 1900;

--SIN
SELECT ID, FIRST_NAME, LAST_NAME, JOB_ID, SALARY
FROM TEST.EMPLOYEES
WHERE JOB_ID = 'AD_CTB' OR JOB_ID = 'FQ_GRT' AND SALARY > 1900;


--Recuperar empleados ordenados por fecha de ingreso (desde más viejo a más nuevo).
SELECT ID, FIRST_NAME, LAST_NAME, HIRE_DATE
FROM [TEST].[EMPLOYEES]
ORDER BY HIRE_DATE ASC;

--Recuperar empleados ordenados por fecha de ingreso descendente y apellido ascendente.
SELECT ID, FIRST_NAME, LAST_NAME, HIRE_DATE
FROM [TEST].[EMPLOYEES]
ORDER BY HIRE_DATE DESC, LAST_NAME ASC;

--Recuperar apellido y salario anual de empleados ordenados por salario anual.
SELECT LAST_NAME, SALARY * 12 AS "ANNUAL_SALARY"
FROM TEST.EMPLOYEES
ORDER BY "ANNUAL_SALARY" DESC;


--Recuperar lista de empleados con la descripción del departamento al que cada uno pertenece. no devuelve los null porque INNER JOIN solo devuelve filas que tengan coincidencias en ambas tablas.
SELECT E.ID, E.FIRST_NAME, E.LAST_NAME, D.DEPARTMENT_NAME
FROM TEST.EMPLOYEES E
INNER JOIN TEST.DEPARTMENTS D ON E.DEPARTMENT_ID = D.ID;

--Recuperar lista de empleados con la descripción del departamento, tengan o no departamento asignado.
SELECT E.ID, E.FIRST_NAME, E.LAST_NAME, D.DEPARTMENT_NAME
FROM TEST.EMPLOYEES E
LEFT JOIN TEST.DEPARTMENTS D ON E.DEPARTMENT_ID = D.ID; --LEFT JOIN devolverá todas las filas de la tabla de la izquierda (en este caso, EMPLOYEES) y las filas coincidentes de la tabla de la derecha (en este caso, DEPARTMENTS). Si no hay una coincidencia en la tabla de la derecha, los valores serán NULL.


--Recuperar lista de departamentos con empleados de cada departamento, tengan o no empleados asociados.
SELECT D.DEPARTMENT_NAME, E.ID, E.FIRST_NAME, E.LAST_NAME
FROM TEST.DEPARTMENTS D
LEFT JOIN TEST.EMPLOYEES E ON D.ID = E.DEPARTMENT_ID;

--Selfjoin Recuperar lista de subordinados por cada mánager
SELECT 
    M.ID AS "MANAGER ID", 
    M.FIRST_NAME AS "MANAGER FIRST_NAME", 
    M.LAST_NAME AS "MANAGER_LAST_NAME", 
    S.FIRST_NAME AS "SUBORDINATED NAME", 
    S.LAST_NAME AS "SUBORDINATED LAST_NAME"
FROM TEST.EMPLOYEES M
LEFT JOIN TEST.EMPLOYEES S ON M.ID = S.MANAGER_ID

--Recuperar máximo, mínimo, promedio, y suma total de salarios de los empleados.
SELECT
    MAX(SALARY) AS Salario_Maximo,
    MIN(SALARY) AS Salario_Minimo,
    AVG(SALARY) AS Salario_Promedio,
    SUM(SALARY) AS Suma_Total_Salarios
FROM TEST.EMPLOYEES
GROUP BY DEPARTMENT_ID;

--Hago lo mismo pero usando join, porque ahora quiero ver el nombre de los departamentos
SELECT
    D.ID,
    D.DEPARTMENT_NAME,
    MAX(E.SALARY) AS Salario_Maximo,
    MIN(E.SALARY) AS Salario_Minimo,
    AVG(E.SALARY) AS Salario_Promedio,
    SUM(E.SALARY) AS Suma_Total_Salarios
FROM TEST.EMPLOYEES E
INNER JOIN TEST.DEPARTMENTS D ON E.DEPARTMENT_ID = D.ID
GROUP BY D.ID, D.DEPARTMENT_NAME;

--Recuperar máximo, mínimo, promedio, y suma total de fecha de contratación de los empleados.
SELECT
    MAX(HIRE_DATE) AS Fecha_Contratacion_Maxima,
    MIN(HIRE_DATE) AS Fecha_Contratacion_Minima,
    AVG(CAST(HIRE_DATE AS FLOAT)) AS Fecha_Contratacion_Promedio
FROM TEST.EMPLOYEES;--NO ESTOY SEGURA SI ESTO ES ASI LO QUE PIDE LA CONSIGNA


--Obtener la cantidad de empleados de cada departamento.
SELECT
    DEPARTMENT_ID,
    COUNT(ID) AS Cantidad_Empleados
FROM TEST.EMPLOYEES
GROUP BY DEPARTMENT_ID;

--Hago un where para evitar los null
SELECT
    [DEPARTMENT_ID],
    COUNT(ID) AS Cantidad_Empleados
FROM TEST.EMPLOYEES
WHERE DEPARTMENT_ID IS NOT NULL
GROUP BY [DEPARTMENT_ID];

--Ahora se me ocurrio hacer un join para mostrar el nombre de los departamentos y evito los null
SELECT
    E.DEPARTMENT_ID,
    D.DEPARTMENT_NAME,
    COUNT(*) AS Cantidad_Empleados
FROM TEST.EMPLOYEES E
LEFT JOIN TEST.DEPARTMENTS D ON E.DEPARTMENT_ID = D.ID
WHERE E.DEPARTMENT_ID IS NOT NULL
GROUP BY E.DEPARTMENT_ID, D.DEPARTMENT_NAME;


--Obtener la cantidad de empleados por cada departamento y job.
SELECT
    [DEPARTMENT_ID],
    [JOB_ID],
    COUNT(ID) AS Cantidad_Empleados
FROM TEST.EMPLOYEES
GROUP BY DEPARTMENT_ID, JOB_ID
ORDER BY DEPARTMENT_ID, JOB_ID;


--Recuperar los departamentos y el salario promedio si es menor a 1200.
SELECT
    [DEPARTMENT_ID],
    AVG(SALARY) AS Salario_Promedio
FROM TEST.EMPLOYEES
GROUP BY [DEPARTMENT_ID]
HAVING AVG(SALARY) < 1200;


--Crear insert de todos los campos en orden.
INSERT INTO TEST.EMPLOYEES (ID, FIRST_NAME, LAST_NAME, SALARY, DEPARTMENT_ID, JOB_ID, HIRE_DATE, MANAGER_ID)
VALUES (19, 'Mayra', 'Riccardi', 60000, 50, 'FQ_OPR', '2023-08-26', 5);

--BORRAR
DELETE FROM TEST.EMPLOYEES
WHERE ID = 22;

--VER IDS
SELECT [FIRST_NAME], [LAST_NAME],[ID]
FROM TEST.EMPLOYEES;

SELECT ID
FROM TEST.DEPARTMENTS;


--AGREGAR CON CAMPOS OBLIGATORIOS 
INSERT INTO TEST.EMPLOYEES (ID, FIRST_NAME, LAST_NAME, HIRE_DATE)
VALUES (20, 'Omar', 'Bonilla', GETDATE());

--Especificar lista de campos obligatorios.
INSERT INTO TEST.EMPLOYEES (ID, FIRST_NAME, LAST_NAME, HIRE_DATE)
VALUES (21, 'Cintia', 'Riccardi', GETDATE());


--Crear un nuevo empleado basado en los datos de Gustavo Boulette:cambiando su nombre aumentando su sueldo en $200.blanqueando su manager
INSERT INTO TEST.EMPLOYEES (ID, FIRST_NAME, LAST_NAME, SALARY, MANAGER_ID, HIRE_DATE)
SELECT 
    (SELECT MAX(ID) + 1 FROM TEST.EMPLOYEES),  
    'Carla',                                   
    'Boulette',                                
    SALARY + 200,                              
    NULL,                                      
    GETDATE()                                  
FROM TEST.EMPLOYEES
WHERE FIRST_NAME = 'Gustavo' AND LAST_NAME = 'Boulette';


--Actualizar salario del empleado 10 a $1100:
UPDATE [TEST].[EMPLOYEES]
SET SALARY = 1100
WHERE ID = 10;


--Aumento 10% a empleados del departamento id 40
UPDATE TEST.EMPLOYEES
SET SALARY = SALARY * 1.10
WHERE DEPARTMENT_ID = 40;


--Eliminar departamentos cuyo ID sea mayor a 50:
DELETE FROM TEST.DEPARTMENTS WHERE ID > 50;


--Eliminar departamento 40:
--primero mando los empleados de ese departamento a otro
UPDATE TEST.EMPLOYEES
SET DEPARTMENT_ID = 50
WHERE DEPARTMENT_ID = 40;
--despues borro, sino no me deja por la FOREIGN KEY
DELETE FROM TEST.DEPARTMENTS WHERE ID = 40;


--Crear la función que retorne la antiguedad en años de cada mpleado donde el parametro de ingreso es el id del empleado
CREATE FUNCTION [dbo].[FnAntiguedadEmpleado](@ID int)RETURNS INT
AS

BEGIN
DECLARE @ANTIGUEDAD INT

SELECT @ANTIGUEDAD = (YEAR(GETDATE()) - YEAR(HIRE_DATE)) FROM TEST.EMPLOYEES 
WHERE EMPLOYEES.ID = @ID

RETURN @ANTIGUEDAD

END


--Store Produce
CREATE PROCEDURE [dbo].[sp_GetNombreAntiguedad]
	
	
AS
BEGIN
	SELECT ID,[FIRST_NAME],[LAST_NAME], dbo.FnAntiguedadEmpleado(ID) AS ANTIGUEDAD
	FROM TEST.EMPLOYEES
	WHERE EMPLOYEES.ID = ID AND EMPLOYEES.ID IS NOT NULL
	ORDER BY HIRE_DATE
	
END