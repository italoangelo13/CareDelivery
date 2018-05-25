function alerta(msg, tipo) {
  var icone = 'success';

  if (tipo == 'erro') {
    icone = 'error';
  } else if (tipo == 'success') {
    icone = 'success';
  } else if (tipo == 'warning') {
    icone = 'warning';
  } else {
    icone = 'info';
  }


  $.toast({
    heading: 'Alerta do sistema!',
    text: msg,
    showHideTransition: 'slide',
    icon: icone,
    position: 5000,
    hideAfter: 'top-center',
    stack: 3,
    loader: true

  });
}