ALTER TABLE dbintegracao.pedido
 DROP FOREIGN KEY FK_pedido_cliente,
 CHANGE bloqueado bloqueado CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Pedido Bloqueado pela API',
 CHANGE importado_api importado_api CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Pedido de venda de produto importada pela API';
ALTER TABLE dbintegracao.pedido
 ADD CONSTRAINT FK_pedido_cliente FOREIGN KEY (Id_cliente) REFERENCES dbintegracao.cliente (Id) ON UPDATE RESTRICT ON DELETE RESTRICT;
