insert into Cliente values('A9A50489-CA6C-400D-B184-DCD0E2DCEB87', '0000', 'Test0', 'Calle Test 0', 'Col. 0', 'Ciudad0', '0000@mail.com', 'Indicaciones', 'RFC00000', '0000 Factura', 'Calle Test 0 Factura', 'Col 0 Factura', 'Ciudad0 Factura', '0000@factura.com')
insert into Cliente values(newid(), '1111', 'Test1', 'Calle Test 1', 'Col. 1', 'Ciudad1', '1111@mail.com', 'Indicaciones', 'RFC11111', '1111 Factura', 'Calle Test 1 Factura', 'Col 1 Factura', 'Ciudad1 Factura', '1111@factura.com')
insert into Cliente values(newid(), '2222', 'Test2', 'Calle Test 2', 'Col. 2', 'Ciudad2', '2222@mail.com', 'Indicaciones', 'RFC22222', '2222 Factura', 'Calle Test 2 Factura', 'Col 2 Factura', 'Ciudad2 Factura', '2222@factura.com')
insert into Cliente values(newid(), '3333', 'Test3', 'Calle Test 3', 'Col. 3', 'Ciudad3', '3333@mail.com', 'Indicaciones', 'RFC33333', '3333 Factura', 'Calle Test 3 Factura', 'Col 3 Factura', 'Ciudad3 Factura', '3333@factura.com')
insert into Cliente values(newid(), '4444', 'Test4', 'Calle Test 4', 'Col. 4', 'Ciudad4', '4444@mail.com', 'Indicaciones', 'RFC44444', '4444 Factura', 'Calle Test 4 Factura', 'Col 4 Factura', 'Ciudad4 Factura', '4444@factura.com')
insert into Cliente values(newid(), '5555', 'Test5', 'Calle Test 5', 'Col. 5', 'Ciudad5', '5555@mail.com', 'Indicaciones', 'RFC55555', '5555 Factura', 'Calle Test 5 Factura', 'Col 5 Factura', 'Ciudad5 Factura', '5555@factura.com')
insert into Cliente values(newid(), '6666', 'Test6', 'Calle Test 6', 'Col. 6', 'Ciudad6', '6666@mail.com', 'Indicaciones', 'RFC66666', '6666 Factura', 'Calle Test 6 Factura', 'Col 6 Factura', 'Ciudad6 Factura', '6666@factura.com')
insert into Cliente values(newid(), '7777', 'Test7', 'Calle Test 7', 'Col. 7', 'Ciudad7', '7777@mail.com', 'Indicaciones', 'RFC77777', '7777 Factura', 'Calle Test 7 Factura', 'Col 7 Factura', 'Ciudad7 Factura', '7777@factura.com')

insert into articulo values('3E098268-EC95-4DC6-AD74-C962C236CE42', '0000', 'Articulo 00', 'M00', 'KG', 5.643, 20.405)
insert into articulo values('04AF94A5-FE91-4D0F-BC40-F4DA9B908AC7', '1111', 'Articulo 11', 'M11', 'PZA', 5.643, 21.415)
insert into articulo values('B1BF202D-DBD9-4CCC-B190-EFFB079E4572', '2222', 'Articulo 22', 'M22', 'KG', 5.643, 22.425)
insert into articulo values('D82E415D-8620-48B4-B55D-C63352F1A0B5', '3333', 'Articulo 33', 'M33', 'KG', 5.643, 23.435)
insert into articulo values(newid(), '4444', 'Articulo 44', 'M44', 'KG', 5.643, 24.445)
insert into articulo values(newid(), '5555', 'Articulo 55', 'M55', 'KG', 5.643, 25.455)
insert into articulo values(newid(), '6666', 'Articulo 66', 'M66', 'PZA', 5.643, 26.465)
insert into articulo values(newid(), '7777', 'Articulo 77', 'M77', 'PZA', 5.643, 27.475)
insert into articulo values(newid(), '8888', 'Articulo 88', 'M88', 'PZA', 5.643, 28.485)
insert into articulo values(newid(), '9999', 'Articulo 99', 'M99', 'PZA', 5.643, 29.495)
insert into articulo values(newid(), '1010', 'Articulo 10', 'M10', 'PZA', 5.643, 20.405)

insert into [Pedido] values('B0691368-566D-4856-81F4-5EB5058949A3', 'A9A50489-CA6C-400D-B184-DCD0E2DCEB87', SYSDATETIME(), null, 0)
insert into [Pedido] values(newid(), 'A9A50489-CA6C-400D-B184-DCD0E2DCEB87', '2010-02-23 13:14:15.16', null, 0)
insert into [Pedido] values(newid(), 'A9A50489-CA6C-400D-B184-DCD0E2DCEB87', '2011-02-23 13:14:15.16', null, 0)

insert into [ArticuloPedido] values('B0691368-566D-4856-81F4-5EB5058949A3', '3E098268-EC95-4DC6-AD74-C962C236CE42', 0.11, 'Indicacion 0')
insert into [ArticuloPedido] values('B0691368-566D-4856-81F4-5EB5058949A3', '04AF94A5-FE91-4D0F-BC40-F4DA9B908AC7', 1.11, 'Indicacion 1')
insert into [ArticuloPedido] values('B0691368-566D-4856-81F4-5EB5058949A3', 'B1BF202D-DBD9-4CCC-B190-EFFB079E4572', 2, 'Indicacion 2')
insert into [ArticuloPedido] values('B0691368-566D-4856-81F4-5EB5058949A3', 'D82E415D-8620-48B4-B55D-C63352F1A0B5', 3, 'Indicacion 3')