ALTER TABLE dbintegracao.pedido_frete
 DROP FOREIGN KEY FK_pedido_frete_pedido,
 CHANGE modalidade modalidade CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Modalidade do Frete';
ALTER TABLE dbintegracao.pedido_frete
 ADD CONSTRAINT FK_pedido_frete_pedido FOREIGN KEY (Id_pedido) REFERENCES dbintegracao.pedido (id) ON UPDATE CASCADE ON DELETE CASCADE;
