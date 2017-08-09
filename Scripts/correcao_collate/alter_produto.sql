ALTER TABLE dbintegracao.produto
 CHANGE bloqueado bloqueado CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Cadastro Bloqueado pela API',
 CHANGE importado_api importado_api CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Gerado pela API',
 CHANGE inativo inativo CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Indica se o cadstro de produto está inativo [S/N]',
 CHANGE descr_detalhada descr_detalhada CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Descrição Detalhada para o Produto',
 CHANGE obs_internas obs_internas CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Observações Internas';
