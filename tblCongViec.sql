USE [CMCIT]
GO

/****** Object:  Table [dbo].[tblCongViec]    Script Date: 9/8/2023 5:34:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCongViec](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaCV] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[CongViec] [nvarchar](50) NOT NULL,
	[NgayThem] [nvarchar](10) NOT NULL,
	[NgayNop] [nvarchar](10) NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
	[TrangThai] [bit] NULL,
	[UuTien] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

