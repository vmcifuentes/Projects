<?php
	/* 
		Crea una sesión o reanuda la actual basada en un identificador de sesión 
		pasado mediante una petición GET o POST, o pasado mediante una cookie.
	*/
	session_start();
	
	$_SESSION['user_id'] = 1; # Asignamos a la superglobal SESSION la llave del usuario
	
	// Simularemos proceso de login (no es correcto hacer esto)
	if(!isset($_SESSION['user_id'])){
		exit('¡No existe usuario logeado en el sistema!');
	}
	//$number = 0;	
?>
