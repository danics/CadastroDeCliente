<script type="text/javascript">
 $(document).ready(function () {
       ("#Cep").focusout(function () {

            var cep = (this).val();

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
                    //CEP pesquisado não foi encontrado.
                    limpa_formulário_cep();
                    alert("CEP não encontrado.");
                }
            });
        });

        function ConverteEstado(sigla) {
            switch(sigla) {
                case 'AL':
                    return 1;
                    break;
                case 'AP':
                    return 2;
                    break;
                case 'AM':
                    return 3;
                    break;
                case 'BA':
                    return 4;
                    break;
                case 'CE':
                    return 5;
                    break;
                case 'ES':
                    return 6;
                    break;
                case 'GO':
                    return 7;
                    break;
                case 'MA':
                    return 8;
                    break;
                case 'MT':
                    return 9;
                    break;
                case 'MS':
                    return 10;
                    break;
                case 'MG':
                    return 11;
                    break;
                case 'PA':
                    return 12;
                    break;
                case 'PB':
                    return 13;
                    break;
                case 'PR':
                    return 14;
                    break;
                case 'PE':
                    return 15;
                    break;
                case 'PI':
                    return 16;
                    break;
                case 'RJ':
                    return 17;
                    break;
                case 'RN':
                    return 18;
                    break;
                case 'RS':
                    return 19;
                    break;
                case 'RO':
                    return 20;
                    break;
                case 'RR':
                    return 21;
                    break;
                case 'SC':
                    return 22;
                    break;
                case 'SP':
                    return 23;
                    break;
                case 'SE':
                    return 24;
                    break;
                case 'TO':
                    return 25;
                    break;
                case 'DF':
                    return 26;
                    break;
         }
       }
});
</script>