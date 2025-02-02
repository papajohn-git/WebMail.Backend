-- Use the database where you want to insert the dummy data

USE [YourDatabaseName]
GO
SET IDENTITY_INSERT [dbo].[Mails] ON 

INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (2, N'string', N'string', 41, CAST(N'2025-01-05T09:35:13.4147459' AS DateTime2), CAST(N'2025-01-05T09:35:48.8028303' AS DateTime2), CAST(N'2025-01-05T11:35:48.8633333' AS DateTime2), N'["bily56@gmail.com"]', N'string', N'4cce05ea-068f-4c73-84ba-3acc474a7f00')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (3, N'string2', N'string', 41, CAST(N'2025-01-05T09:48:50.2226623' AS DateTime2), CAST(N'2025-01-05T09:49:13.6961953' AS DateTime2), CAST(N'2025-01-05T11:49:13.7433333' AS DateTime2), N'["bily56@gmail.com"]', N'string', N'88b1f21d-9323-46b8-89f4-17f50c91e849')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (4, N'string', N'string', 41, CAST(N'2025-01-05T13:15:20.0517684' AS DateTime2), CAST(N'2025-01-05T13:15:20.1285514' AS DateTime2), CAST(N'2025-01-05T15:15:20.2666667' AS DateTime2), N'["string","bily56@gmail.com","aaaaaa@mycompany.com"]', N'string', N'24028503-918e-450e-8897-cd2a83572043')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (5, N'kalhmera', N'kalhmera', 41, CAST(N'2025-01-11T18:57:20.7127280' AS DateTime2), CAST(N'2025-01-11T18:57:20.8749668' AS DateTime2), CAST(N'2025-01-11T20:57:21.1266667' AS DateTime2), N'["string55","string77","string88","string"]', N'string', N'acb7a070-5ac3-48c0-8c2c-bf2f714280d9')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (6, N'kalhmera', N'kalhmera', 41, CAST(N'2025-01-11T18:59:30.5274328' AS DateTime2), CAST(N'2025-01-11T18:59:30.5304707' AS DateTime2), CAST(N'2025-01-11T20:59:30.5433333' AS DateTime2), N'["string"]', N'string', N'3fe2e203-ce64-47f2-81ce-80f2356ccc58')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (7, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:13:30.7000240' AS DateTime2), CAST(N'2025-01-12T22:13:30.7467842' AS DateTime2), CAST(N'2025-01-13T00:13:30.7766667' AS DateTime2), N'["john.doe@mycompany.com"]', N'app_team@yourcompany.com', N'024c728f-19a0-4649-b4f0-2a391b7aede8')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (8, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:16:18.2297555' AS DateTime2), CAST(N'2025-01-12T22:16:18.2317752' AS DateTime2), CAST(N'2025-01-13T00:16:18.2400000' AS DateTime2), N'["jane.smith@mycompany.com"]', N'app_team@yourcompany.com', N'9593d845-f7e8-471d-b4df-e33c7282cc0f')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (9, N'New mail Test', N'Hello,

This is a test email to verify that the email functionality is working correctly. 

Please disregard this message.

Thank you!', 49, CAST(N'2025-01-12T22:22:04.0909777' AS DateTime2), CAST(N'2025-01-12T22:22:04.0919468' AS DateTime2), CAST(N'2025-01-13T00:22:04.1000000' AS DateTime2), N'["john.doe@mycompany.com","jane.smith@mycompany.com"]', N'jane.smith@mycompany.com', N'6b55f6f4-da6b-462f-8556-6064365dfad5')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (10, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:29:17.6209429' AS DateTime2), CAST(N'2025-01-12T22:29:17.6220545' AS DateTime2), CAST(N'2025-01-13T00:29:17.6300000' AS DateTime2), N'["mike.jones@mycompany.com"]', N'app_team@yourcompany.com', N'0d22eb3a-7438-4c70-9cbf-c0637b02f178')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (11, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:31:19.0395453' AS DateTime2), CAST(N'2025-01-12T22:31:19.0405496' AS DateTime2), CAST(N'2025-01-13T00:31:19.0500000' AS DateTime2), N'["susan.brown@mycompany.com"]', N'app_team@yourcompany.com', N'ff5c305f-f497-4244-9e2e-dc9bb83483c3')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (12, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:33:25.7623361' AS DateTime2), CAST(N'2025-01-12T22:33:25.7632395' AS DateTime2), CAST(N'2025-01-13T00:33:25.7733333' AS DateTime2), N'["david.wilson@mycompany.com"]', N'app_team@yourcompany.com', N'a951eb5e-7d91-4eaf-82c6-fef7c2d2dd3d')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (13, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:35:27.5266048' AS DateTime2), CAST(N'2025-01-12T22:35:27.5277686' AS DateTime2), CAST(N'2025-01-13T00:35:27.5333333' AS DateTime2), N'["linda.miller@mycompany.com"]', N'app_team@yourcompany.com', N'9ca82108-23f1-4120-8b00-8ad0437c82be')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (14, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:37:01.7909540' AS DateTime2), CAST(N'2025-01-12T22:37:01.7920234' AS DateTime2), CAST(N'2025-01-13T00:37:01.8000000' AS DateTime2), N'["james.taylor@mycompany.com"]', N'app_team@yourcompany.com', N'472dc4a9-3a80-432a-a6d9-4785f4aa73cc')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (15, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:38:44.0970988' AS DateTime2), CAST(N'2025-01-12T22:38:44.0988374' AS DateTime2), CAST(N'2025-01-13T00:38:44.1033333' AS DateTime2), N'["patricia.anderson@mycompany.com"]', N'app_team@yourcompany.com', N'95ec2ea7-4d9f-4707-b454-6e40179f53bd')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (16, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:42:57.4993871' AS DateTime2), CAST(N'2025-01-12T22:42:57.5005535' AS DateTime2), CAST(N'2025-01-13T00:42:57.5066667' AS DateTime2), N'["robert.thomas@mycompany.com"]', N'app_team@yourcompany.com', N'763cab32-b4db-4a55-be09-b3f070c14117')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (17, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-12T22:45:06.4641232' AS DateTime2), CAST(N'2025-01-12T22:45:06.4649951' AS DateTime2), CAST(N'2025-01-13T00:45:06.4733333' AS DateTime2), N'["jennifer.jackson@mycompany.com"]', N'app_team@yourcompany.com', N'1ec31499-d95e-4d85-a66b-689eac6f29ee')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (18, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-13T12:48:41.7462736' AS DateTime2), CAST(N'2025-01-13T12:48:41.8540346' AS DateTime2), CAST(N'2025-01-13T14:48:41.9066667' AS DateTime2), N'["karen.martinez@mycompany.com"]', N'app_team@yourcompany.com', N'13c80be5-41ef-4e58-9942-c8853ed746d4')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (19, N'Email Test', N'Hello,

This is a test email to verify that the email functionality is working correctly. 

Please disregard this message.

Thank you!', 48, CAST(N'2025-01-13T19:38:08.2453697' AS DateTime2), CAST(N'2025-01-13T19:38:08.3067529' AS DateTime2), CAST(N'2025-01-13T21:38:08.4900000' AS DateTime2), N'["john.doe@mycompany.com","mike.jones@mycompany.com","jennifer.jackson@mycompany.com","david.wilson@mycompany.com","james.taylor@mycompany.com","jane.smith@mycompany.com"]', N'john.doe@mycompany.com', N'561f6e45-55ed-4388-891b-26722120694b')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (20, N'New mail Test', N'hellow', 48, CAST(N'2025-01-13T20:57:28.1699067' AS DateTime2), CAST(N'2025-01-13T20:57:28.1816925' AS DateTime2), CAST(N'2025-01-13T22:57:28.2033333' AS DateTime2), N'["string"]', N'john.doe@mycompany.com', N'3b97c493-dd02-4fa3-83b7-3f97be5e8c09')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (21, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-13T21:00:26.0212629' AS DateTime2), CAST(N'2025-01-13T21:00:26.0221474' AS DateTime2), CAST(N'2025-01-13T23:00:26.0300000' AS DateTime2), N'["user@example.com"]', N'app_team@yourcompany.com', N'5b261f29-e053-48d0-a382-6107b05c34bd')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (22, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-15T20:58:24.7766607' AS DateTime2), CAST(N'2025-01-15T20:58:24.8158769' AS DateTime2), CAST(N'2025-01-15T22:58:24.8400000' AS DateTime2), N'["admin@mycompany.com"]', N'app_team@yourcompany.com', N'93068849-a04d-4302-b199-be10074a9bdb')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (23, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-15T22:17:28.2119847' AS DateTime2), CAST(N'2025-01-15T22:17:28.2510344' AS DateTime2), CAST(N'2025-01-16T00:17:28.2666667' AS DateTime2), N'["newuser@mycompany.com"]', N'app_team@yourcompany.com', N'594976aa-478d-4f9d-ab13-2cccec2cb0c9')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (24, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-16T22:28:47.3719630' AS DateTime2), CAST(N'2025-01-16T22:28:47.3731042' AS DateTime2), CAST(N'2025-01-17T00:28:47.3800000' AS DateTime2), N'["newuser@mycompany.com"]', N'app_team@yourcompany.com', N'fe715cf4-b49b-4ebb-afb4-3f82b8d46cfb')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (25, N'Test Message', N'Coding Factory', 62, CAST(N'2025-01-16T22:30:53.6979749' AS DateTime2), CAST(N'2025-01-16T22:30:53.6987862' AS DateTime2), CAST(N'2025-01-17T00:30:53.7066667' AS DateTime2), N'["admin@mycompany.com","newuser@mycompany.com"]', N'newuser@mycompany.com', N'2bbff8f2-2411-463a-b6a9-36bde6f22305')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (26, N'Test Message', N'Good morning!!!', 60, CAST(N'2025-01-18T23:16:36.6577009' AS DateTime2), CAST(N'2025-01-18T23:16:36.6782363' AS DateTime2), CAST(N'2025-01-19T01:16:36.7000000' AS DateTime2), N'["admin@mycompany.com","john.doe@mycompany.com"]', N'admin@mycompany.com', N'68a1cef9-ff72-49ab-b75a-4a69ce11aaea')
INSERT [dbo].[Mails] ([Id], [Subject], [Body], [SenderId], [SendAt], [CreatedAt], [UpdatedAt], [Recipients], [SenderEmail], [GuidMail]) VALUES (27, N'Welcome to Our Service', N'Welcome to our service! We''re glad to have you on board.

Best regards,
The App Team', 0, CAST(N'2025-01-22T15:59:03.6152974' AS DateTime2), CAST(N'2025-01-22T15:59:03.6624424' AS DateTime2), CAST(N'2025-01-22T17:59:03.6833333' AS DateTime2), N'["sarah.thompson@mycompany.com"]', N'app_team@yourcompany.com', N'3d4ed89d-ee19-44f7-8f59-5ea1da7f4903')
SET IDENTITY_INSERT [dbo].[Mails] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (48, N'john.doe@mycompany.com', N'$2a$11$0Q5PI9LfuZ59LxHzXA1I0eV9zw1tj5g10Ub671oVp78Eyme5Yi4KK', N'12345', N'Admin', CAST(N'2025-01-12T22:13:30.0941911' AS DateTime2), CAST(N'2025-01-13T00:13:30.2766667' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (49, N'jane.smith@mycompany.com', N'$2a$11$HRcMvRejpP0pthyI1LLBlOcg5IIoHR8GOBuGcWIg2LJqLiNrkpoti', N'12345', N'User', CAST(N'2025-01-12T22:16:18.0470123' AS DateTime2), CAST(N'2025-01-13T00:16:18.0566667' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (50, N'mike.jones@mycompany.com', N'$2a$11$ye8YQI9LZxt6KAv2LvbuCuL4Is0EJ6Ibrpw12pGDxsaslSHzWHNgq', N'12345', N'User', CAST(N'2025-01-12T22:29:17.4293981' AS DateTime2), CAST(N'2025-01-13T00:29:17.4400000' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (51, N'susan.brown@mycompany.com', N'$2a$11$wgxwiGz08FaOgPiCx7mNeOkMtClSxNhmuLwyZdkAFGZ/0leWvYuLG', N'12345', N'User', CAST(N'2025-01-12T22:31:18.8553617' AS DateTime2), CAST(N'2025-01-13T00:31:18.8666667' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (52, N'david.wilson@mycompany.com', N'$2a$11$M5tRlV0P7N/98OQ/IpdzbeSDzK6EoGuKuSqYgvKt6bFDcoPpn5PYa', N'12345', N'User', CAST(N'2025-01-12T22:33:25.5928009' AS DateTime2), CAST(N'2025-01-13T00:33:25.6033333' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (53, N'linda.miller@mycompany.com', N'$2a$11$IbEcslgEdZq4BTyDNOHWSuK0H82uCUj.iGk6SD0RDO0pLHnKcr8N2', N'12345', N'User', CAST(N'2025-01-12T22:35:27.3756397' AS DateTime2), CAST(N'2025-01-13T00:35:27.3833333' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (54, N'james.taylor@mycompany.com', N'$2a$11$faUrzbwLcaM2bVhfaiK3gejK2.jgSvzmrwOoOBIlG7vC6wdfPseeS', N'12345', N'User', CAST(N'2025-01-12T22:37:01.6073764' AS DateTime2), CAST(N'2025-01-13T00:37:01.6166667' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (55, N'patricia.anderson@mycompany.com', N'$2a$11$M2wShndPgSGqVUGm8tNPw.RelranmCqhEQVWK0greebcXkC3Sixaq', N'12345', N'User', CAST(N'2025-01-12T22:38:43.9291263' AS DateTime2), CAST(N'2025-01-13T00:38:43.9400000' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (56, N'robert.thomas@mycompany.com', N'$2a$11$jlfsQteIJtwYitGBEpUeG.bIsdDn4LJi5DHzrygfUQ7BsIdhmr8Eq', N'12345', N'User', CAST(N'2025-01-12T22:42:57.3517004' AS DateTime2), CAST(N'2025-01-13T00:42:57.3566667' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (57, N'jennifer.jackson@mycompany.com', N'$2a$11$W.YTqPXow.7vmFw62gqLQ.63uZ7zxnoQsk5pQISzVFLPYRUVpzddG', N'12345', N'User', CAST(N'2025-01-12T22:45:06.3112471' AS DateTime2), CAST(N'2025-01-13T00:45:06.3166667' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (59, N'user@example.com', N'$2a$11$ISEgPloO1.bJrJYH4L8gouUIl/86afKLZAsFWh3mOUJ3Zq5QBBr/2', N'string', N'User', CAST(N'2025-01-13T21:00:25.7981840' AS DateTime2), CAST(N'2025-01-13T23:00:25.8133333' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (60, N'admin@mycompany.com', N'$2a$11$POD5nJxcu7AmSiXXvfDVPe.U38Crcb.L5boM79LgR0sH4i2/VfdJe', N'admin', N'Admin', CAST(N'2025-01-15T20:58:24.3471928' AS DateTime2), CAST(N'2025-01-15T22:58:24.4466667' AS DateTime2))
INSERT [dbo].[Users] ([ID], [Email], [Password], [ConfirmPassword], [UserRole], [CreatedAt], [UpdatedAt]) VALUES (63, N'sarah.thompson@mycompany.com', N'$2a$11$erAOJpf/4X1YKxCpS59z1uGY/hkzw0kxAxvjCz3DoiMsOvGTDWaDK', N'12345', N'User', CAST(N'2025-01-22T15:59:03.0980977' AS DateTime2), CAST(N'2025-01-22T17:59:03.2033333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (48, 7, 0, 0, 0, CAST(N'2025-01-12T22:13:30.8694607' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (48, 9, 0, 0, 0, CAST(N'2025-01-12T22:22:04.2144585' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (48, 19, 0, 0, 0, CAST(N'2025-01-13T19:38:08.6715784' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (48, 26, 0, 0, 0, CAST(N'2025-01-18T23:16:36.8724463' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (49, 8, 0, 0, 0, CAST(N'2025-01-12T22:16:18.2940331' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (49, 9, 0, 0, 0, CAST(N'2025-01-12T22:22:04.2391129' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (49, 19, 0, 0, 0, CAST(N'2025-01-13T19:38:08.8191577' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (50, 10, 0, 0, 0, CAST(N'2025-01-12T22:29:17.6860249' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (50, 19, 0, 0, 0, CAST(N'2025-01-13T19:38:08.6985221' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (51, 11, 0, 0, 0, CAST(N'2025-01-12T22:31:19.0993440' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (52, 12, 0, 0, 0, CAST(N'2025-01-12T22:33:25.8277983' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (52, 19, 0, 0, 0, CAST(N'2025-01-13T19:38:08.7508124' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (53, 13, 0, 0, 0, CAST(N'2025-01-12T22:35:27.5879793' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (54, 14, 0, 0, 0, CAST(N'2025-01-12T22:37:01.8489493' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (54, 19, 0, 0, 0, CAST(N'2025-01-13T19:38:08.7759316' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (55, 15, 0, 0, 0, CAST(N'2025-01-12T22:38:44.1628589' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (56, 16, 0, 0, 0, CAST(N'2025-01-12T22:42:57.5484923' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (57, 17, 0, 0, 0, CAST(N'2025-01-12T22:45:06.5213531' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (57, 19, 0, 0, 0, CAST(N'2025-01-13T19:38:08.7232165' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (59, 21, 0, 0, 0, CAST(N'2025-01-13T21:00:26.0692506' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (60, 22, 0, 0, 0, CAST(N'2025-01-15T20:58:24.9152696' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (60, 25, 0, 0, 0, CAST(N'2025-01-16T22:30:53.8127224' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (60, 26, 0, 0, 0, CAST(N'2025-01-18T23:16:36.8365192' AS DateTime2), NULL)
INSERT [dbo].[UserMails] ([UserId], [MailId], [Id], [IsDeleted], [IsRead], [ReceivedAt], [ReadAt]) VALUES (63, 27, 0, 0, 0, CAST(N'2025-01-22T15:59:03.7782775' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[Folders] ON 

INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (72, N'Inbox', 48, CAST(N'2025-01-12T22:13:30.5382020' AS DateTime2), CAST(N'2025-01-13T00:13:30.6200000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (73, N'Sent Items', 48, CAST(N'2025-01-12T22:13:30.5382160' AS DateTime2), CAST(N'2025-01-13T00:13:30.6200000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (74, N'Deleted Items', 48, CAST(N'2025-01-12T22:13:30.5383386' AS DateTime2), CAST(N'2025-01-13T00:13:30.6200000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (75, N'Inbox', 49, CAST(N'2025-01-12T22:16:18.1332141' AS DateTime2), CAST(N'2025-01-13T00:16:18.1700000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (76, N'Sent Items', 49, CAST(N'2025-01-12T22:16:18.1332278' AS DateTime2), CAST(N'2025-01-13T00:16:18.1700000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (77, N'Deleted Items', 49, CAST(N'2025-01-12T22:16:18.1332407' AS DateTime2), CAST(N'2025-01-13T00:16:18.1700000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (78, N'Inbox', 50, CAST(N'2025-01-12T22:29:17.5446375' AS DateTime2), CAST(N'2025-01-13T00:29:17.5733333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (79, N'Sent Items', 50, CAST(N'2025-01-12T22:29:17.5446751' AS DateTime2), CAST(N'2025-01-13T00:29:17.5733333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (80, N'Deleted Items', 50, CAST(N'2025-01-12T22:29:17.5446878' AS DateTime2), CAST(N'2025-01-13T00:29:17.5733333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (81, N'Inbox', 51, CAST(N'2025-01-12T22:31:18.9392095' AS DateTime2), CAST(N'2025-01-13T00:31:18.9866667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (82, N'Sent Items', 51, CAST(N'2025-01-12T22:31:18.9392220' AS DateTime2), CAST(N'2025-01-13T00:31:18.9866667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (83, N'Deleted Items', 51, CAST(N'2025-01-12T22:31:18.9392344' AS DateTime2), CAST(N'2025-01-13T00:31:18.9866667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (84, N'Inbox', 52, CAST(N'2025-01-12T22:33:25.6793659' AS DateTime2), CAST(N'2025-01-13T00:33:25.7200000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (85, N'Sent Items', 52, CAST(N'2025-01-12T22:33:25.6793791' AS DateTime2), CAST(N'2025-01-13T00:33:25.7200000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (86, N'Deleted Items', 52, CAST(N'2025-01-12T22:33:25.6794197' AS DateTime2), CAST(N'2025-01-13T00:33:25.7200000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (87, N'Inbox', 53, CAST(N'2025-01-12T22:35:27.4581524' AS DateTime2), CAST(N'2025-01-13T00:35:27.4866667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (88, N'Sent Items', 53, CAST(N'2025-01-12T22:35:27.4581647' AS DateTime2), CAST(N'2025-01-13T00:35:27.4866667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (89, N'Deleted Items', 53, CAST(N'2025-01-12T22:35:27.4581764' AS DateTime2), CAST(N'2025-01-13T00:35:27.4866667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (90, N'Inbox', 54, CAST(N'2025-01-12T22:37:01.7211537' AS DateTime2), CAST(N'2025-01-13T00:37:01.7500000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (91, N'Sent Items', 54, CAST(N'2025-01-12T22:37:01.7211658' AS DateTime2), CAST(N'2025-01-13T00:37:01.7500000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (92, N'Deleted Items', 54, CAST(N'2025-01-12T22:37:01.7211776' AS DateTime2), CAST(N'2025-01-13T00:37:01.7500000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (93, N'Inbox', 55, CAST(N'2025-01-12T22:38:44.0219016' AS DateTime2), CAST(N'2025-01-13T00:38:44.0500000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (94, N'Sent Items', 55, CAST(N'2025-01-12T22:38:44.0219152' AS DateTime2), CAST(N'2025-01-13T00:38:44.0500000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (95, N'Deleted Items', 55, CAST(N'2025-01-12T22:38:44.0219275' AS DateTime2), CAST(N'2025-01-13T00:38:44.0500000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (96, N'Inbox', 56, CAST(N'2025-01-12T22:42:57.4290109' AS DateTime2), CAST(N'2025-01-13T00:42:57.4600000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (97, N'Sent Items', 56, CAST(N'2025-01-12T22:42:57.4290234' AS DateTime2), CAST(N'2025-01-13T00:42:57.4600000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (98, N'Deleted Items', 56, CAST(N'2025-01-12T22:42:57.4290356' AS DateTime2), CAST(N'2025-01-13T00:42:57.4600000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (99, N'Inbox', 57, CAST(N'2025-01-12T22:45:06.3901368' AS DateTime2), CAST(N'2025-01-13T00:45:06.4133333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (100, N'Sent Items', 57, CAST(N'2025-01-12T22:45:06.3901492' AS DateTime2), CAST(N'2025-01-13T00:45:06.4133333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (101, N'Deleted Items', 57, CAST(N'2025-01-12T22:45:06.3901612' AS DateTime2), CAST(N'2025-01-13T00:45:06.4133333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (105, N'Inbox', 59, CAST(N'2025-01-13T21:00:25.9177546' AS DateTime2), CAST(N'2025-01-13T23:00:25.9733333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (106, N'Sent Items', 59, CAST(N'2025-01-13T21:00:25.9177675' AS DateTime2), CAST(N'2025-01-13T23:00:25.9733333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (107, N'Deleted Items', 59, CAST(N'2025-01-13T21:00:25.9177798' AS DateTime2), CAST(N'2025-01-13T23:00:25.9733333' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (116, N'Inbox', 60, CAST(N'2025-01-15T20:58:24.6611249' AS DateTime2), CAST(N'2025-01-15T22:58:24.7266667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (117, N'Sent Items', 60, CAST(N'2025-01-15T20:58:24.6611378' AS DateTime2), CAST(N'2025-01-15T22:58:24.7266667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (118, N'Deleted Items', 60, CAST(N'2025-01-15T20:58:24.6611513' AS DateTime2), CAST(N'2025-01-15T22:58:24.7266667' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (140, N'New Folder 1', 60, CAST(N'2025-01-18T23:31:42.4648733' AS DateTime2), CAST(N'2025-01-19T01:31:42.4700000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (141, N'New Folder 2', 60, CAST(N'2025-01-18T23:32:09.3066103' AS DateTime2), CAST(N'2025-01-19T01:32:09.3100000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (142, N'Inbox', 63, CAST(N'2025-01-22T15:59:03.4361028' AS DateTime2), CAST(N'2025-01-22T17:59:03.5500000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (143, N'Sent Items', 63, CAST(N'2025-01-22T15:59:03.4361156' AS DateTime2), CAST(N'2025-01-22T17:59:03.5500000' AS DateTime2))
INSERT [dbo].[Folders] ([Id], [FolderName], [UserId], [CreatedAt], [UpdatedAt]) VALUES (144, N'Deleted Items', 63, CAST(N'2025-01-22T15:59:03.4361293' AS DateTime2), CAST(N'2025-01-22T17:59:03.5500000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Folders] OFF
GO
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (72, 7)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (75, 8)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (72, 9)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (75, 9)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (76, 9)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (78, 10)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (81, 11)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (84, 12)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (87, 13)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (90, 14)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (93, 15)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (96, 16)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (99, 17)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (72, 19)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (73, 19)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (75, 19)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (78, 19)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (84, 19)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (90, 19)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (99, 19)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (73, 20)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (105, 21)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (116, 22)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (72, 26)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (116, 26)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (117, 26)
INSERT [dbo].[FolderMails] ([FolderId], [MailId]) VALUES (142, 27)
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] ON 

INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (5, N'John', N'Doe', N'555-1234-555', N'123 Elm St', N'Springfield', N'IL', N'62701', 48, CAST(N'2025-01-12T22:15:21.9542404' AS DateTime2), CAST(N'2025-01-15T22:01:34.6007514' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (6, N'Jane', N'Smith', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 49, CAST(N'2025-01-12T22:17:55.2940604' AS DateTime2), CAST(N'2025-01-12T22:19:19.7470135' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (7, N'Mike', N'Jones', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 50, CAST(N'2025-01-12T22:29:53.2629617' AS DateTime2), CAST(N'2025-01-12T22:29:53.2629547' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (8, N'Susan', N'Brown', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 51, CAST(N'2025-01-12T22:32:46.5496165' AS DateTime2), CAST(N'2025-01-12T22:41:44.8819523' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (9, N'David', N'Wilson', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 52, CAST(N'2025-01-12T22:34:20.0629039' AS DateTime2), CAST(N'2025-01-12T22:42:33.0243743' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (10, N'Linda', N'Miller', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 53, CAST(N'2025-01-12T22:36:19.9588377' AS DateTime2), CAST(N'2025-01-12T22:36:19.9586188' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (11, N'James', N'Taylor', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 54, CAST(N'2025-01-12T22:37:43.9155293' AS DateTime2), CAST(N'2025-01-12T22:37:43.9155226' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (12, N'Patricia', N'Anderson', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 55, CAST(N'2025-01-12T22:39:19.9444244' AS DateTime2), CAST(N'2025-01-12T22:39:27.4785402' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (13, N'Robert', N'Thomas', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 56, CAST(N'2025-01-12T22:43:40.2164643' AS DateTime2), CAST(N'2025-01-12T22:43:40.2164575' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (14, N'Jennifer', N'Jackson', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 57, CAST(N'2025-01-12T22:45:51.7555505' AS DateTime2), CAST(N'2025-01-12T22:45:51.7555437' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (16, N'string', N'string', N'string', N'string', N'string', N'string', N'string', 59, CAST(N'2025-01-13T21:00:53.5459472' AS DateTime2), CAST(N'2025-01-13T21:00:53.5459403' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (17, N'admin', N'admin', N'555-5678', N'456 Oak St', N'Springfield', N'IL', N'62701', 60, CAST(N'2025-01-15T20:59:24.0117704' AS DateTime2), CAST(N'2025-01-15T20:59:24.0117633' AS DateTime2))
INSERT [dbo].[UserProfiles] ([ID], [FirstName], [LastName], [PhoneNumber], [Address], [City], [State], [ZipCode], [UserId], [CreatedAt], [UpdatedAt]) VALUES (20, N'Sarah', N'Thompson', N'555-1234-555', N'123 Elm St', N'Springfield', N'IL', N'62701', 63, CAST(N'2025-01-22T16:02:01.9223395' AS DateTime2), CAST(N'2025-01-22T16:02:01.9223309' AS DateTime2))
SET IDENTITY_INSERT [dbo].[UserProfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[ToDos] ON 

INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (8, 48, N'New Task 2', 0, 0, CAST(N'2025-01-13T20:40:39.3646510' AS DateTime2), CAST(N'2025-01-13T22:40:39.3800000' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (9, 48, N'New Task 3', 1, 0, CAST(N'2025-01-13T20:40:48.3483521' AS DateTime2), CAST(N'2025-01-13T22:40:48.3566667' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (15, 59, N'New Task', 1, 0, CAST(N'2025-01-13T21:01:49.3862018' AS DateTime2), CAST(N'2025-01-13T23:01:49.3933333' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (17, 59, N'New Task 6', 1, 0, CAST(N'2025-01-13T21:10:14.7812051' AS DateTime2), CAST(N'2025-01-13T23:10:14.7866667' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (18, 59, N'New Task 7', 1, 0, CAST(N'2025-01-13T21:10:21.0039392' AS DateTime2), CAST(N'2025-01-13T23:10:21.0166667' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (19, 59, N'New Task 11', 1, 0, CAST(N'2025-01-13T21:15:37.8564031' AS DateTime2), CAST(N'2025-01-13T23:15:37.8600000' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (22, 59, N'New Task 12', 1, 0, CAST(N'2025-01-13T21:26:56.6981546' AS DateTime2), CAST(N'2025-01-13T23:26:56.7066667' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (23, 59, N'New Task 65', 0, 0, CAST(N'2025-01-13T21:33:21.2117001' AS DateTime2), CAST(N'2025-01-13T23:33:21.2400000' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (25, 59, N'New Task 76', 1, 0, CAST(N'2025-01-13T21:33:37.7849711' AS DateTime2), CAST(N'2025-01-13T23:33:37.7966667' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (26, 59, N'New Task 76', 0, 0, CAST(N'2025-01-13T21:33:50.3709815' AS DateTime2), CAST(N'2025-01-13T23:33:50.3900000' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (35, 63, N'New Task', 0, 0, CAST(N'2025-01-22T16:05:25.2803311' AS DateTime2), CAST(N'2025-01-22T18:05:25.3066667' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (36, 63, N'New Task 2', 1, 0, CAST(N'2025-01-22T16:05:29.7078046' AS DateTime2), CAST(N'2025-01-22T18:05:29.7066667' AS DateTime2))
INSERT [dbo].[ToDos] ([Id], [UserId], [Task], [IsCompleted], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (37, 63, N'New Task 3', 0, 0, CAST(N'2025-01-22T16:05:33.6513137' AS DateTime2), CAST(N'2025-01-22T18:05:33.6500000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ToDos] OFF
GO
