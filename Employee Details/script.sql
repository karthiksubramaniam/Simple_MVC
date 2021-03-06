USE [Employee_db]
GO
/****** Object:  Table [dbo].[employee_details]    Script Date: 02/02/2017 1:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employee_details](
	[pkid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[salary] [decimal](18, 2) NOT NULL,
	[yearofexp] [decimal](3, 1) NULL,
	[designation] [varchar](50) NULL,
	[joineddate] [date] NULL,
 CONSTRAINT [PK_employee_details] PRIMARY KEY CLUSTERED 
(
	[pkid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
