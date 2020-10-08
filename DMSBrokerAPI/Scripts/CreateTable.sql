﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ERP_QUEUE_BROKER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FUNCTION_NAME] [varchar](30) NOT NULL,
	[FUNCTION_PARAMETER] [nvarchar](30) NULL,
	[EXECUTION_STATUS] [bit] NOT NULL,
 CONSTRAINT [PK_ERP_Queue_Broker2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ERP_QUEUE_BROKER] ADD  CONSTRAINT [DF_ERP_Queue_Broker_Execution_status2]  DEFAULT ((0)) FOR [EXECUTION_STATUS]
GO