<?php
	require_once 'app/init.php';
	require_once 'app/database.php';

	if(isset($_GET['as'],$_GET['id'])){
		$as = $_GET['as'];
		$id	= $_GET['id'];
		
		switch($as){
			case 'done':
				$update->execute([
					'id'=>$id,
					'user'=>$_SESSION['user_id']
				]);
			break;
		}
	}
	
	header('Location: index.php');
?>