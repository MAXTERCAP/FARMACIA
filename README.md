# Farmacia
Pre requisitos para windows 7:

Sql Server 2014
Link
ExpressAndTools 64BIT\SQLEXPRWT_x64_ESN.exe

- SQLManagementStudio
- SQLSERVEReXPRESS

VISUAL STUDIO 2022

Tomamos desde 
https://www.youtube.com/watch?v=5x79o72E0pw&t=35s&ab_channel=JEVSOFT

Patron de diseño MVC
https://developer.mozilla.org/es/docs/Glossary/MVC

#Casos de Uso
Alta, Baja y Modificacion de Medicamentos (ABM)

Breve descripcion: Ingresar, modificar, eliminar un medicamento en la base de datos

Precondicion: 
-Debe haberse logeado al sistema con usuario y contraseña

Post condicion:
- En el caso de un nuevo medicamento se genera un codigo unico en el sistema para esa medicacion 
- En el caso de eliminacion o edicion se informa el resultado de la operacion

Curso normal:
1- Se ingresa al menu de gestion de medicamentos
2- El sistema muestr un formulario de ABM Medicamento
3- Se ingresa el alta del medicamento y se completa los datos solicitados por el sistema para realizar el alta del meedicamento en el sistema
4- El sistema checkea que la medicacion sea unica en la Base de Datos y muestra un mensaje "Medicacion ingresada correctamente"
5- Vuelve al paso 
Fin caso de uso

Curso Alternativo 1: Modificar Medicamento

1- Se ingresa al Menú
2- El sistema muestra la interfaz “FormularioABMMedicamento.jpg”. 
3- El asistente busca al medicamento por el campo deseado y modifica los datos deseados 
4- El sistema verifica los datos ingresados sean válidos.
5- Si el sistema logra realizar la operación correctamente, el sistema muestra el mensaje “Se actualizaron los datos correctamente”. 
6- Vuelve al paso 
Fin caso de uso.

Curso Alternativo 2: Eliminar un medicamento 

1-Se ingresa al menú 

2- El sistema muestra la interfaz “FormularioABMMedicamento.jpg”. 

3- Se busca la medicación que desea para realiza la eliminación del mismo. 

4- El sistema realiza el cambio solicitado y el sistema muestra el mensaje “medicamento eliminado correctamente” 

5- Vuelve al paso
Fin caso de uso

----------
SQL SERVER
----------
Cambiar en el archivo Web.config cambie lo siguiente:
-> donde dice:
  <connectionStrings>
    <add name="BD_FARMACIAEntities3" connectionString="............ data source=PABLO-PC\SQLEXPRESS......."

-> reemplazarlo por: el data-source que corresponda (generalmente <nombre-pc>\sqlexpress, ver el nombre en mgmt-studio)

Ademas deben crearse 3 tablas asi:
DROP TABLE [dbo].[TB_MEDICAMENTOS];
CREATE TABLE [dbo].[TB_MEDICAMENTOS](
	[ID] [int] IDENTITY NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](50) NULL,
	[CANTIDAD] [int] NULL,
	[PRECIO] [decimal](18, 0) NULL,
	[GRAMAJE] [varchar](50) NULL,
	[TIPO_PASTILLAS] [varchar](50) NULL,
	[DOBLE_RECETA] [varchar](1) NULL,
	[PRESENTACION] [varchar](50) NULL,
	[LABORATORIO] [varchar](50) NULL,
 CONSTRAINT [PK_TB_MEDICAMENTOS] PRIMARY KEY CLUSTERED 
( [ID] ASC  ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
);

DROP TABLE [dbo].[TB_LABORATORIO];
CREATE TABLE [dbo].[TB_LABORATORIO](
	[nombre] [nchar](30) NOT NULL,
	[descripcion] [nchar](100) NULL,
	[CUIT] [nchar](13) NULL,
	[direccion] [nchar](100) NULL,
	[contacto] [nchar](50) NULL,
 CONSTRAINT [PK_TB_LABORATORIO] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

DROP TABLE [dbo].[TB_PRESENTACION_LIST];
CREATE TABLE [dbo].[TB_PRESENTACION_LIST](
	[nombre] [nchar](20) NOT NULL,
 CONSTRAINT [PK_TB_PRESENTACION_LIST] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

Por ultimo, deben ejecutarse estas 2 sentencias sql:
INSERT INTO TB_PRESENTACION_LIST VALUES ('Gotas');
INSERT INTO TB_PRESENTACION_LIST VALUES ('Comprimidos');
