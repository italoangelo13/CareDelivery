function alerta(msg, tipo, titulo) {
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
      text: msg, // Text that is to be shown in the toast
      heading: titulo, // Optional heading to be shown on the toast
      icon: icone, // Type of toast icon
      showHideTransition: 'slide', // fade, slide or plain
      allowToastClose: true, // Boolean value true or false
      hideAfter: 5000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
      stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
      position: 'top-left', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



      textAlign: 'left',  // Text alignment i.e. left, right or center
      loader: true,  // Whether to show loader or not. True by default
      loaderBg: '#9EC600',  // Background color of the toast loader
      beforeShow: function () { }, // will be triggered before the toast is shown
      afterShown: function () { }, // will be triggered after the toat has been shown
      beforeHide: function () { }, // will be triggered before the toast gets hidden
      afterHidden: function () { }  // will be triggered after the toast has been hidden
  });
}