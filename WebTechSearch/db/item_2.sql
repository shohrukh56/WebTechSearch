CREATE DATABASE items
GO
USE items
GO
CREATE TABLE computers
(
    [Id]          INT           NOT NULL,
    [name]  VARCHAR(50)      NULL,
    [old_price]    FLOAT           NULL,
    [current_price] FLOAT NULL, 
    [savings] FLOAT NULL, 
    [processor] FLOAT NULL, 
    [os] VARCHAR(50) NULL, 
    [video_card] VARCHAR(50) NULL, 
    [hard_drive] VARCHAR(50) NULL, 
    [memory] VARBINARY(50) NULL, 
    [screen] VARCHAR(50) NULL, 
    [updated_at] DATETIME NULL, 
    [created_at] DATETIME NULL, 
	[ulr] VARCHAR(300) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
)
GO