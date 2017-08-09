ALTER TABLE dbintegracao.itempedido
 DROP FOREIGN KEY fk_itempedido_pedido,
 CHANGE simples_nacional simples_nacional CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs;
ALTER TABLE dbintegracao.itempedido
 ADD CONSTRAINT fk_itempedido_pedido FOREIGN KEY (id_pedido) REFERENCES dbintegracao.pedido (id) ON UPDATE CASCADE ON DELETE CASCADE;
