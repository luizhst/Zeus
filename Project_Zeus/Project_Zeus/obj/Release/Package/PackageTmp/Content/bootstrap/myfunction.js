/**
  * Função para criar um objeto XMLHTTPRequest
  */
 function CriaRequest() {
     try{
         request = new XMLHttpRequest();        
     }catch (IEAtual){
         
         try{
             request = new ActiveXObject("Msxml2.XMLHTTP");       
         }catch(IEAntigo){
         
             try{
                 request = new ActiveXObject("Microsoft.XMLHTTP");          
             }catch(falha){
                 request = false;
             }
         }
     }
     
     if (!request) 
         alert("Seu Navegador não suporta Ajax!");
     else
         return request;
 }
 
 /**
  * Função para enviar os dados
  */

            function limpa_formulario_cep() {
                // Limpa valores do formulário de cep.
                $("#txtRua").val("");                
               $("#txtCidade").val("");
               $("#txtUf").val("");
			   $("#txtBairro").val("");

            }

            //Quando o campo cep perde o foco.
            function ProcurarCep() {

				//var NovoCEP = document.getElementById("cep").value;
                //Nova variável "cep" somente com dígitos.
                var cep = document.getElementById("txtCep").value;

                //Verifica se campo cep possui valor informado.
                if (cep != "") {

                    //Expressão regular para validar o CEP.
                    var validacep = /^[0-9]{8}$/;

                    //Valida o formato do CEP.
                    if(validacep.test(cep)) {

                        //Preenche os campos com "..." enquanto consulta webservice.
                        $("#txtRua").val("...");
                        $("#txtBairro").val("...");
                        $("#txtCidade").val("...");
                        $("#txtUf").val("...");

                        //Consulta o webservice viacep.com.br/
                        $.getJSON("//viacep.com.br/ws/"+ cep +"/json/?callback=?", function(dados) {

                            if (!("erro" in dados)) {
                                //Atualiza os campos com os valores da consulta.
                                $("#txtRua").val(dados.logradouro);
                                $("#txtBairro").val(dados.bairro);
                                $("#txtCidade").val(dados.localidade);
                                $("#txtUf").val(dados.uf);
                            } //end if.
                            else {
                                //CEP pesquisado não foi encontrado.
                                limpa_formulario_cep();
                                alert("CEP não encontrado.");
                            }
                        });
                    } //end if.
                    else {
                        //cep é inválido.
                        limpa_formulario_cep();
                        alert("Formato de CEP inválido.");
                    }
                } //end if.
                else {
                    //cep sem valor, limpa formulário.
                    limpa_formulario_cep();
                }
            }

function logarAqui(){
	
	var usuario = document.getElementById("username").value;
	var psenha = document.getElementById("password").value;	
	var result = document.getElementById("resposta");
    var xmlreq = CriaRequest();
	var result2;
	
	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
	 xmlreq.open("GET", "function/conectar_login.php?usu=" + usuario + "&senha=" + psenha + "&acao=0", true);
		 
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == 1) {
								 
								 result.innerHTML = "<b><center>Bem-Vindo...Aguarde</center></b>";
								 window.location.href = "http://www.fourkey.com.br/Walle/admin/home.php";
								 
							 }else{
								 
								if (result2 == '1') {


									result.innerHTML = xmlreq.responseText;
									// result.innerHTML = "<b><center>Bem-Vindo... Aguarde</center></b>";
								 	// window.location.href = "http://www.fourkey.com.br/Walle/admin/home.php";

								}else if (result2 == '-1') {

									result.innerHTML = "<font color='#A52A2A'><b><center>Sua conta está bloqueada, por favor entre em contato com o seu administrador.</center></b></font>";

								}else if (result2 == '0') {

									result.innerHTML = "<font color='#A52A2A'><b><center>Dados inválidos</center></b></font>";

								}
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);
	
}

function EmaildeRecuperacao(){
	
	var usuario = document.getElementById("email").value;
	var result = document.getElementById("resposta2");
    var xmlreq = CriaRequest();
	var result2;
	
	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
	 xmlreq.open("GET", "function/conectar_login.php?usu=" + usuario + "&acao=1", true);
		 
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {
								 
								 result.innerHTML = "<b><center>Solicitação enviada com sucesso! <br> Por favor, verifique se a mesma não foi encaminhada para a caixa de spam de seu provedor.</center></b>";
								 usuario.value = "";

							 }else{

								result.innerHTML = "<font color='#A52A2A'><b><center>Não foi possível realizar a solicitação, por favor tente novamente.</center></b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);
	
}

function ConfirmacaoRecuperacao(){
	
	var senha = document.getElementById("new-password").value;
	var csenha = document.getElementById("conf-password").value;
	var result = document.getElementById("resposta-recovery");
    var xmlreq = CriaRequest();
	var result2;
	
	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
	 xmlreq.open("GET", "function/conectar_login.php?usu=" + senha + "&senha=" + csenha + "&acao=2", true);
		 
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {
								 
								 result.innerHTML = "<b><center>Senha alterada com sucesso, você será redirecionado(a).</center></b>";
								 window.location.href = "http://www.fourkey.com.br/Walle/admin/";

							 }else if(xmlreq.responseText == "2" || xmlreq.responseText == 2){

								result.innerHTML = "<font color='#A52A2A'><b><center>Atenção: As senhas não conferem, por favor tente novamente.</center></b></font>";

							 }else if(xmlreq.responseText == "3" || xmlreq.responseText == 3){

								result.innerHTML = "<font color='#A52A2A'><b><center>Atenção: Sua senha deve conter no mínimo 8 caracteres.</center></b></font>";

							 }							 
							 else{

								result.innerHTML = "<font color='#A52A2A'><b><center>Não foi possível realizar a solicitação, seu código pode ter expirado ou não existe, por favor tente novamente.</center></b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);
	
}

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

function CadastrarArea(){

	var txtNomeArea = document.getElementById("txtNomeArea").value;
	var result = document.getElementById("result");
    var xmlreq = CriaRequest();

	 xmlreq.open("GET", "function/CRUD_TB_Area.php?txtNomeArea=" + txtNomeArea + "&acao=0", true);

	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {
								 
									result.innerHTML = "<b>Área Cadastrada</b>";								
									document.getElementById('txtNomeArea').value='';
									SelectArea();

							 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 2){

								result.innerHTML = "<font color='#A52A2A'><b><center>Houve um erro ao cadastrar.</center></b></font>";

							 }						 
							 else{

								result.innerHTML = "<font color='#A52A2A'><b><center>Já existe uma área cadastrada com este nome</center></b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}


function SelectArea(){

	var result = document.getElementById("tabela_area");
    var xmlreq = CriaRequest();

	 xmlreq.open("GET", "function/CRUD_TB_Area.php?acao=1", true);

	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							result.innerHTML = xmlreq.responseText;					 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}


function CadastrarGrupo(){

	var txtNomeGrupo = document.getElementById("txtNomeGrupo").value;
	var ComboArea = document.getElementById("ComboArea").value;
	var result = document.getElementById("result2");
    var xmlreq = CriaRequest();

	  xmlreq.open("GET", "function/CRUD_TB_Grupo.php?txtNomeGrupo=" + txtNomeGrupo
													+ "&ComboArea=" + ComboArea, true);

	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {
								 
									result.innerHTML = "<b>Grupo Cadastrado</b>";								
									document.getElementById('txtNomeGrupo').value='';
								  	document.getElementById('txtNomeGrupo').value='Selecione...';

							 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 2){

								result.innerHTML = "<font color='#A52A2A'><b>Houve um erro ao cadastrar.</b></font>";

							 }						 
							 else{

								result.innerHTML = "<font color='#A52A2A'><b>Já existe uma área cadastrada com este nome</b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);

}

function limpa_formulario_form_cliente() {
                // Limpa valores do formulário de cep.
                $("#txtRazaoSocial").val("");                
				$("#txtBairro").val("");
				$("#txtCep").val("");
				$("#txtCNPJCPF").val("");
				$("#txtCidade").val("");
				$("#txtComplemento").val("");
				$("#txtCriptografia").val("");
				$("#txtInscricaoEstadual").val("");
				$("#txtNomeFantasia").val("");
				$("#txtNumero").val("");
				$("#txtRua").val("");
				$("#txtSerialAtivacao").val("");
				$("#txtUf").val("");

}

$(document).ready(function() {
    $('.bottom').click(function() {
        $('html, body').animate({
            scrollTop: $(document).height()
        }, 1500);
        return false;
    });

    $('.middle').click(function() {
        $('html, body').animate({
            scrollTop: '2000px'
        }, 1500);
        return false;
    });

    $('.topmove').click(function() {
        $('html, body').animate({
            scrollTop: '0px'
        }, 1500);
        return false;
    });
});