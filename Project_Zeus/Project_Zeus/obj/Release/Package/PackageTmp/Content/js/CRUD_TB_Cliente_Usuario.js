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

function CadastrarClienteUsuarioAdmin(){

	var comboGrupo = document.getElementById("comboGrupo").value;
    var txtNomeCompleto = document.getElementById("txtNomeCompleto").value;
    var txtUsuariodeRede = document.getElementById("txtUsuariodeRede").value;
    var txtCPF = document.getElementById("txtCPF").innerHTML;
    var txtMatricula = document.getElementById("txtMatricula").value;
    var txtDtaNascimento = document.getElementById("txtDtaNascimento").value;
    var txtDtaContratacao = document.getElementById("txtDtaContratacao").value;
    var comboArea = document.getElementById("comboArea").value;
    var xmlreq = CriaRequest();
    var result = document.getElementById("resultado");
    var result2;

	//txtNomeCompleto = txtNomeCompleto.replace("'", "");
    //txtUsuariodeRede = txtUsuariodeRede.replace("'", "");

    //txtNomeCompleto = txtNomeCompleto.trim();
    //txtUsuariodeRede = txtUsuariodeRede.trim();
 
    if (comboGrupo != "0" && comboArea != "0") {

      //  if(txtNomeCompleto != "" && txtMatricula != ""){             

               alert(txtNomeCompleto + txtMatricula);

      //  }else{

      //          alert("Passou");

   //    }

        }else{

            result.innerHTML = "<font color='#A52A2A'><b>Selecione a Área e o Grupo y" + txtNomeCompleto + "</b></font>";

    } 

}

function SelectUsuario(){

	var result = document.getElementById("tabela_usuarios");
	var retorno;
	var tabela = "";
	var combo = "";
	var cont = 0;
    var xmlreq = CriaRequest();

	 xmlreq.open("GET", "function/CRUD_TB_Cliente_Usuario.php?acao=0", true);

	//result.innerHTML = '<center><img src="../plugins/images/gif/Progresso_2.gif" height="40px" width="40px" /></center>';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							//result2 = unescape(xmlreq.responseText);

							retorno = xmlreq.responseText;

							result.innerHTML = retorno;

							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}

function SelectGrupoFiltro(area){
	
	var result = document.getElementById("FiltroGrupo");
    var xmlreq = CriaRequest();
	
	 xmlreq.open("GET", "function/CRUD_TB_Grupo.php?acao=2&area="+area, true);

	//result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 alert(area);
							//result2 = unescape(xmlreq.responseText);
							result.innerHTML = xmlreq.responseText;
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}

function limpa_formulario_form_usuario(){

    
    document.getElementById("txt_Nome").value = "";
    document.getElementById("txt_NomeCompleto").value = "";
    document.getElementById("txt_Login").value = "";
    document.getElementById("validacao").innerHTML = "";
    document.getElementById("txt_Senha").value;
    document.getElementById("txt_Dta_Cadastro").value = "";
    document.getElementById("comboSituacao").value = "0";
    document.getElementById("rdbAtivo").value = "1";
    document.getElementById("comboPerfil").value = "0";

}