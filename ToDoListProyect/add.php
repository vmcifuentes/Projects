<?php
	require_once 'app/init.php';
	require_once 'app/database.php';	
	
	if(isset($_POST['name'])){
		$name = trim($_POST['name']);
		
		if(!empty($name)){
			
			$insert->execute([
				'user' => $_SESSION['user_id'],
				'name' => $name
			]);
		}
	}

	# header es utilizado para enviar encabezados HTTP sin formato.
	header('Location:index.php');
?>