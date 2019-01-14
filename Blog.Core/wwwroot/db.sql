USE [WMBlogDB]
GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 8/23/2018 1:04:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Createdate] [datetime] NOT NULL,
	[ImgUrl] [nvarchar](512) NULL,
	[Title] [nvarchar](64) NULL,
	[Url] [nvarchar](256) NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Advertisement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogArticle]    Script Date: 8/23/2018 1:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogArticle](
	[bID] [int] IDENTITY(1,1) NOT NULL,
	[bsubmitter] [nvarchar](60) NULL,
	[btitle] [nvarchar](256) NULL,
	[bcategory] [nvarchar](max) NULL,
	[bcontent] [text] NULL,
	[btraffic] [int] NOT NULL,
	[bcommentNum] [int] NOT NULL,
	[bUpdateTime] [datetime] NOT NULL,
	[bCreateTime] [datetime] NOT NULL,
	[bRemark] [nvarchar](max) NULL,
 CONSTRAINT [PK_BlogArticle] PRIMARY KEY CLUSTERED 
(
	[bID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guestbook]    Script Date: 8/23/2018 1:04:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guestbook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[blogId] [int] NOT NULL,
	[createdate] [datetime] NOT NULL,
	[username] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[QQ] [nvarchar](max) NULL,
	[body] [nvarchar](max) NULL,
	[ip] [nvarchar](max) NULL,
	[isshow] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Guestbook] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 8/23/2018 1:04:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[LinkUrl] [nvarchar](100) NULL,
	[Area] [nvarchar](max) NULL,
	[Controller] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
	[Icon] [nvarchar](100) NULL,
	[Code] [nvarchar](10) NULL,
	[OrderSort] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsMenu] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModulePermission]    Script Date: 8/23/2018 1:04:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModulePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[ModuleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.ModulePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperateLog]    Script Date: 8/23/2018 1:04:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperateLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[Area] [nvarchar](max) NULL,
	[Controller] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
	[IPAddress] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[LogTime] [datetime] NULL,
	[LoginName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
	[User_uID] [int] NULL,
 CONSTRAINT [PK_dbo.OperateLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordLib]    Script Date: 8/23/2018 1:04:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordLib](
	[PLID] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[plURL] [nvarchar](200) NULL,
	[plPWD] [nvarchar](100) NULL,
	[plAccountName] [nvarchar](200) NULL,
	[plStatus] [int] NULL,
	[plErrorCount] [int] NULL,
	[plHintPwd] [nvarchar](200) NULL,
	[plHintquestion] [nvarchar](200) NULL,
	[plCreateTime] [datetime] NULL,
	[plUpdateTime] [datetime] NULL,
	[plLastErrTime] [datetime] NULL,
	[test] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PasswordLib] PRIMARY KEY CLUSTERED 
(
	[PLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 8/23/2018 1:04:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[OrderSort] [int] NOT NULL,
	[Icon] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[Enabled] [bit] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/23/2018 1:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[OrderSort] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleModulePermission]    Script Date: 8/23/2018 1:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModulePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[RoleId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[PermissionId] [int] NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.RoleModulePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysUserInfo]    Script Date: 8/23/2018 1:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysUserInfo](
	[uID] [int] IDENTITY(1,1) NOT NULL,
	[uLoginName] [nvarchar](60) NULL,
	[uLoginPWD] [nvarchar](60) NULL,
	[uRealName] [nvarchar](60) NULL,
	[uStatus] [int] NOT NULL,
	[uRemark] [nvarchar](max) NULL,
	[uCreateTime] [datetime] NOT NULL,
	[uUpdateTime] [datetime] NOT NULL,
	[uLastErrTime] [datetime] NOT NULL,
	[uErrorCount] [int] NOT NULL,
 CONSTRAINT [PK_dbo.sysUserInfo] PRIMARY KEY CLUSTERED 
(
	[uID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 8/23/2018 1:04:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tLogo] [nvarchar](200) NULL,
	[tName] [nvarchar](200) NULL,
	[tDetail] [nvarchar](400) NULL,
	[tSectendDetail] [nvarchar](200) NULL,
	[tIsDelete] [bit] NOT NULL,
	[tRead] [int] NOT NULL,
	[tCommend] [int] NOT NULL,
	[tGood] [int] NOT NULL,
	[tCreatetime] [datetime] NOT NULL,
	[tUpdatetime] [datetime] NOT NULL,
	[tAuthor] [nvarchar](200) NULL,
 CONSTRAINT [PK_dbo.Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TopicDetail]    Script Date: 8/23/2018 1:04:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopicDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopicId] [int] NOT NULL,
	[tdLogo] [nvarchar](200) NULL,
	[tdName] [nvarchar](200) NULL,
	[tdContent] [nvarchar](max) NULL,
	[tdDetail] [nvarchar](400) NULL,
	[tdSectendDetail] [nvarchar](200) NULL,
	[tdIsDelete] [bit] NOT NULL,
	[tdRead] [int] NOT NULL,
	[tdCommend] [int] NOT NULL,
	[tdGood] [int] NOT NULL,
	[tdCreatetime] [datetime] NOT NULL,
	[tdUpdatetime] [datetime] NOT NULL,
	[tdTop] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TopicDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 8/23/2018 1:04:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TopicDetail] ADD  DEFAULT ((0)) FOR [tdTop]
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Module_dbo.Module_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_dbo.Module_dbo.Module_ParentId]
GO
ALTER TABLE [dbo].[ModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModulePermission_dbo.Module_ModuleId] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModulePermission] CHECK CONSTRAINT [FK_dbo.ModulePermission_dbo.Module_ModuleId]
GO
ALTER TABLE [dbo].[ModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModulePermission_dbo.Permission_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModulePermission] CHECK CONSTRAINT [FK_dbo.ModulePermission_dbo.Permission_PermissionId]
GO
ALTER TABLE [dbo].[OperateLog]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OperateLog_dbo.sysUserInfo_User_uID] FOREIGN KEY([User_uID])
REFERENCES [dbo].[sysUserInfo] ([uID])
GO
ALTER TABLE [dbo].[OperateLog] CHECK CONSTRAINT [FK_dbo.OperateLog_dbo.sysUserInfo_User_uID]
GO
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Module_ModuleId] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Module_ModuleId]
GO
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Permission_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Permission_PermissionId]
GO
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Role_RoleId]
GO
ALTER TABLE [dbo].[TopicDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TopicDetail_dbo.Topic_TopicId] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topic] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TopicDetail] CHECK CONSTRAINT [FK_dbo.TopicDetail_dbo.Topic_TopicId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.sysUserInfo_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[sysUserInfo] ([uID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.sysUserInfo_UserId]
GO