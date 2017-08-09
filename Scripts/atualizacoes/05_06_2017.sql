ALTER TABLE dbintegracao.pedido_otica_infoadic
 DROP FOREIGN KEY fk_pedido_otica_infoadic,
 CHANGE crm_medico crm_medico VARCHAR(20);
ALTER TABLE dbintegracao.pedido_otica_infoadic
 ADD CONSTRAINT fk_pedido_otica_infoadic FOREIGN KEY (id_pedido_otica) REFERENCES dbintegracao.pedido_otica (Id) ON UPDATE CASCADE ON DELETE CASCADE;
ALTER TABLE dbintegracao.pedido_otica
 DROP FOREIGN KEY FK_pedido_otica_caixa,
 DROP FOREIGN KEY FK_pedido_otica_cliente_cliente,
 DROP FOREIGN KEY FK_pedido_otica_motivo_entrega,
 DROP FOREIGN KEY FK_pedido_otica_parcela,
 DROP FOREIGN KEY FK_pedido_otica_pedido,
 DROP FOREIGN KEY FK_pedido_otica_transportadora,
 DROP FOREIGN KEY FK_pedido_otica_venedor,
 CHANGE hora_previsao_entrega hora_previsao_entrega VARCHAR(8) COMMENT 'hora da previsão de entrega';
ALTER TABLE dbintegracao.pedido_otica
 ADD CONSTRAINT FK_pedido_otica_caixa FOREIGN KEY (Id_caixa) REFERENCES dbintegracao.caixa (Id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_pedido_otica_cliente_cliente FOREIGN KEY (Id_cliente) REFERENCES dbintegracao.cliente (Id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_pedido_otica_motivo_entrega FOREIGN KEY (id_motivo_entrega) REFERENCES dbintegracao.motivo_entrega (Id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_pedido_otica_parcela FOREIGN KEY (condicao_pagamento) REFERENCES dbintegracao.parcela (Id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_pedido_otica_pedido FOREIGN KEY (Id_pedido) REFERENCES dbintegracao.pedido (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_pedido_otica_transportadora FOREIGN KEY (Id_transportadora) REFERENCES dbintegracao.cliente (Id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_pedido_otica_venedor FOREIGN KEY (Id_vendedor) REFERENCES dbintegracao.vendedor (Id) ON UPDATE RESTRICT ON DELETE RESTRICT;
