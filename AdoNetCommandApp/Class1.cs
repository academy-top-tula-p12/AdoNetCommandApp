/*

CREATE DATABASE AcademyDB

CREATE TABLE [dbo].[Department] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [title]   VARCHAR (100) NOT NULL,
    [head_id] INT           NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Department_Teacher] FOREIGN KEY ([head_id]) REFERENCES [dbo].[Teacher] ([id])
);
GO
CREATE NONCLUSTERED INDEX [IX_Title]
    ON [dbo].[Department]([title] ASC);
GO



CREATE TABLE [dbo].[Teacher] (
    [id]            INT          IDENTITY (1, 1) NOT NULL,
    [first_name]    VARCHAR (50) NULL,
    [last_name]     VARCHAR (50) NOT NULL,
    [birth_date]    DATE         NULL,
    [phone]         VARCHAR (50) NULL,
    [department_id] INT          NULL,
    CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Teacher_Departmet] FOREIGN KEY ([department_id]) REFERENCES [dbo].[Department] ([id])
);
GO


CREATE TABLE [dbo].[Group] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [title]   VARCHAR (100) NOT NULL,
    [head_id] INT           NULL,
    CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Group_Student] FOREIGN KEY ([head_id]) REFERENCES [dbo].[Student] ([id])
);
GO

CREATE TABLE [dbo].[Student] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [first_name] VARCHAR (50) NULL,
    [last_name]  VARCHAR (50) NOT NULL,
    [birth_date] DATE         NULL,
    [phone]      VARCHAR (50) NULL,
    [group_id]   INT          NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Student_Group] FOREIGN KEY ([group_id]) REFERENCES [dbo].[Group] ([id])
);



CREATE TABLE [dbo].[Module] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [title] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([id] ASC)
);



CREATE TABLE [dbo].[StudyPlan] (
    [group_id]   INT  NOT NULL,
    [teacher_id] INT  NOT NULL,
    [module_id]  INT  NOT NULL,
    [date_begin] DATE NULL,
    [date_end]   DATE NULL,
    CONSTRAINT [PK_StudyPlan] PRIMARY KEY CLUSTERED ([group_id] ASC, [teacher_id] ASC, [module_id] ASC),
    CONSTRAINT [FK_StudyPlan_Group] FOREIGN KEY ([group_id]) REFERENCES [dbo].[Group] ([id]),
    CONSTRAINT [FK_StudyPlan_Module] FOREIGN KEY ([module_id]) REFERENCES [dbo].[Module] ([id]),
    CONSTRAINT [FK_StudyPlan_Teacher] FOREIGN KEY ([teacher_id]) REFERENCES [dbo].[Teacher] ([id])
);

*/
