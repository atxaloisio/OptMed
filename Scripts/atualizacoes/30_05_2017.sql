ALTER TABLE dbintegracao.pedido_otica_infoadic
 DROP FOREIGN KEY fk_pedido_otica_infoadic,
 ADD od_gp_eixo INT(11) AFTER ordem_servico,
 ADD oe_gp_eixo INT(11),
 ADD od_gp_alt VARCHAR(10),
 ADD oe_gp_alt VARCHAR(10);
ALTER TABLE dbintegracao.pedido_otica_infoadic
 ADD CONSTRAINT fk_pedido_otica_infoadic FOREIGN KEY (id_pedido_otica) REFERENCES dbintegracao.pedido_otica (Id) ON UPDATE CASCADE ON DELETE CASCADE;
