$(document).ready(function () {
    $("#Cep").focusout(function () {

        var cep = $(this).val().replace(/\D/g, '');
        var validacep = /^[0-9]{8}$/;

        if (validacep.test(cep)) {

            $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
                if (!("erro" in dados)) {
                    //Atualiza os campos com os valores da consulta.
                    $("#Endereco").val(dados.logradouro);
                    $("#Bairro").val(dados.bairro);
                    $("#Cidade").val(dados.localidade);
                    $("#Estado").val(ConverteEstado(dados.uf));
                    $("#Numero").focus();
                }
                else {
                    //Cep pesquisado não foi encontrado.
                    LimpaFormularioCep();
                    alert("CEP não encontrado.");
                }
            });
        }
        else {
            //cep sem valor, limpa formulário.
            LimpaFormularioCep();
            alert("Favor informar um CEP válido.");
        }
        });

        function ConverteEstado(sigla) {
            switch(sigla) {
                case 'AL':
                    return 1;                   
                case 'AP':
                    return 2;                    
                case 'AM':
                    return 3;                    
                case 'BA':
                    return 4;                    
                case 'CE':
                    return 5;                    
                case 'ES':
                    return 6;                    
                case 'GO':
                    return 7;                    
                case 'MA':
                    return 8;                    
                case 'MT':
                    return 9;                    
                case 'MS':
                    return 10;                    
                case 'MG':
                    return 11;                    
                case 'PA':
                    return 12;                    
                case 'PB':
                    return 13;                    
                case 'PR':
                    return 14;                    
                case 'PE':
                    return 15;                    
                case 'PI':
                    return 16;                    
                case 'RJ':
                    return 17;                    
                case 'RN':
                    return 18;                    
                case 'RS':
                    return 19;                    
                case 'RO':
                    return 20;                    
                case 'RR':
                    return 21;                    
                case 'SC':
                    return 22;                    
                case 'SP':
                    return 23;                    
                case 'SE':
                    return 24;                    
                case 'TO':
                    return 25;                    
                case 'DF':
                    return 26;                    
         }
     }

     function LimpaFormularioCep() {
         $("#Cep").val("");
         $("#Endereco").val("");
         $("#Bairro").val("");
         $("#Cidade").val("");
         $("#Estado").val("");        
     }
});