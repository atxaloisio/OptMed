ALTER TABLE dbintegracao.itempedido_produto
 DROP FOREIGN KEY FK_itempedido_produto_itempedido,
 DROP FOREIGN KEY FK_itempedido_produto_produto,
 CHANGE tipo_desconto tipo_desconto CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Tipo do desconto: (V)alor ou (P)ercentual';
ALTER TABLE dbintegracao.itempedido_produto
 ADD CONSTRAINT FK_itempedido_produto_itempedido FOREIGN KEY (Id_itempedido) REFERENCES dbintegracao.itempedido (id) ON UPDATE CASCADE ON DELETE CASCADE,
 ADD CONSTRAINT FK_itempedido_produto_produto FOREIGN KEY (Id_produto) REFERENCES dbintegracao.produto (id) ON UPDATE RESTRICT ON DELETE RESTRICT;
