SET IDENTITY_INSERT [dbo].[PortCateories] ON
--电源
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (1, N'2020-12-12 00:00:00', 0, N'power in', N'电源输入', N'power', N'PI', 0)
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (2, N'2020-12-12 00:00:00', 0, N'power out', N'电源输出', N'power', N'PO', 1)

--HDMI
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (3, N'2020-12-12 00:00:00', 0, N'hdmi in', N'HDMI输入', N'hdmi', N'HI', 0)
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (4, N'2020-12-12 00:00:00', 0, N'hdmi out', N'HDMI输出', N'hdmi', N'HO', 1)

--Audio
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (5, N'2020-12-12 00:00:00', 0, N'audio in', N'音频输入', N'audio', N'AI', 0)
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (6, N'2020-12-12 00:00:00', 0, N'auddio out', N'音频输出', N'audio', N'AO', 1)

--IO
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (7, N'2020-12-12 00:00:00', 0, N'io', N'IO', N'io', N'IO', 0)
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (8, N'2020-12-12 00:00:00', 0, N'realy', N'继电器', N'io', N'TL', 1)

--LAN
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (9, N'2020-12-12 00:00:00', 0, N'lan', N'网络', N'network', N'NW', 2)
--serial
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (10, N'2020-12-12 00:00:00', 0, N'serial', N'串口', N'serial', N'SL', 2)
		
--ir
INSERT INTO [dbo].[PortCateories] ([Id], [CreateTime], [IsRemoved], [Name], [Description], [Group], [Code], [Value]) 
		VALUES (11, N'2020-12-12 00:00:00', 0, N'IR', N'红外', N'ir', N'IR', 2)



SET IDENTITY_INSERT [dbo].[PortCateories] OFF


 --result.Add(new PortCateoryDTO { Id = 2, Name = "power out",Code = "PO" ,Description = "电源输出", Group = "power", Value = 1 });

 --//Hdmi
 --result.Add(new PortCateoryDTO { Id = 3, Name = "hdmi in",Code = "HI" ,Description = "HDMI输入", Group = "hdmi", Value = 0 });
 --result.Add(new PortCateoryDTO { Id = 4, Name = "hdmi out",Code = "HO", Description = "HDMI输出", Group = "hdmi", Value = 1 });

 --//Audio
 --result.Add(new PortCateoryDTO { Id = 5, Name = "audio in",Code ="AI" ,Description = "音频输入", Group = "audio", Value = 0 });
 --result.Add(new PortCateoryDTO { Id = 6, Name = "auddio out",Code = "AO" ,Description = "音频输出", Group = "audio", Value = 1 });

 --//io
 --result.Add(new PortCateoryDTO { Id = 7, Name = "io", Code = "IO", Description = "IO", Group = "io", Value = 0 });
 --result.Add(new PortCateoryDTO { Id = 8, Name = "realy",Code = "TL" ,Description = "继电器", Group = "io", Value = 1 });

 --//lan
 --result.Add(new PortCateoryDTO { Id = 9, Name = "lan",Code="NW" ,Description = "网络", Group = "network", Value = 2 });
 --//serial
 --result.Add(new PortCateoryDTO { Id = 10, Name = "serial",Code="SL", Description = "串口", Group = "serial", Value = 2 });
 --//ir
 --result.Add(new PortCateoryDTO { Id = 11, Name = "ir",Code = "IR", Description = "红外", Group = "ir", Value = 2 });