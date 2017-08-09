ALTER TABLE dbintegracao.cliente_tag
 DROP FOREIGN KEY FK_cliente_tag_cliente,
 DROP FOREIGN KEY FK_cliente_tag_tag;
ALTER TABLE dbintegracao.cliente_tag
 ADD CONSTRAINT FK_cliente_tag_cliente FOREIGN KEY (Id_cliente) REFERENCES dbintegracao.cliente (Id) ON UPDATE CASCADE ON DELETE CASCADE,
 ADD CONSTRAINT FK_cliente_tag_tag FOREIGN KEY (Id_tag) REFERENCES dbintegracao.tag (Id) ON UPDATE RESTRICT ON DELETE RESTRICT;
