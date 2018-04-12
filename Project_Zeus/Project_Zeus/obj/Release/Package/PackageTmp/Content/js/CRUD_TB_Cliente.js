function CadastrarCliente(){

	var txtRazaoSocial = document.getElementById("txtRazaoSocial").value;
	var txtNomeFantasia = document.getElementById("txtNomeFantasia").value;
	var txtCNJCPF = document.getElementById("txtCNPJCPF").value;
	var comboMatriz = document.getElementById("comboMatriz").value;
	var txtInscricaoEstadual = document.getElementById("txtInscricaoEstadual").value;
	var rdbAtivo = document.getElementById("rdbAtivo").value;
	var rdbInativo = document.getElementById("rdbInativo").value;
	var txtCriptografia = document.getElementById("txtCriptografia").value;
	var txtSerialAtivacao = document.getElementById("txtSerialAtivacao").value;
	var txtCEP = document.getElementById("txtCep").value;
	var txtRua = document.getElementById("txtRua").value;
	var txtNumero = document.getElementById("txtNumero").value;
	var txtComplemento = document.getElementById("txtComplemento").value;
	var txtBairro = document.getElementById("txtBairro").value;
	var txtCidade = document.getElementById("txtCidade").value;
	var txtUF = document.getElementById("txtUf").value;
	var result2 = document.getElementById("result2");
    var xmlreq = CriaRequest();

	 xmlreq.open("GET", "function/CRUD_TB_Cliente.php?txtRazaoSocial=" + txtRazaoSocial
	 												+ "&txtNomeFantasia=" + txtNomeFantasia
													+ "&txtCNJCPF=" + txtCNJCPF
													+ "&comboMatriz=" + comboMatriz
													+ "&txtInscricaoEstadual=" + txtInscricaoEstadual
													+ "&rdbAtivo=" + rdbAtivo
													+ "&rdbInativo=" + rdbInativo
													+ "&txtCriptografia=" + txtCriptografia
													+ "&txtSerialAtivacao=" + txtSerialAtivacao
													+ "&txtCEP=" + txtCEP
													+ "&txtRua=" + txtRua
													+ "&txtNumero=" + txtNumero
													+ "&txtComplemento=" + txtComplemento
													+ "&txtBairro=" + txtBairro
													+ "&txtCidade=" + txtCidade
													+ "&txtUF=" + txtUF, true);


			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {
								 
								 result.innerHTML = "<b><center>Cliente cadastrado com sucesso</center></b>";								

								 limpa_formulario_form_cliente();

							 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 2){

								result.innerHTML = "<font color='#A52A2A'><b><center>Houve um erro ao cadastrar.</center></b></font>";

							 }						 
							 else{

								result.innerHTML = "<font color='#A52A2A'><b><center>Já existe um CNPJ/CPF com estes dados</center></b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}