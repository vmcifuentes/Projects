<?php
	require_once 'init.php';
	require_once 'credentials.php';
	/*
		PDO (PHP Data Object) - https://www.php.net/manual/es/class.pdo.php
		
		PDO::prepare() = Prepara una sentencia para su ejecución y devuelve un objeto sentencia
		PDO::execute() = Ejecuta una sentencia preparada
		PDO::rowCount() = Devuelve el número de filas afectadas por la última sentencia SQL
	*/

	$db = new PDO('mysql:dbname=' . DB_NAME . ';host=' . DB_SERVER . ';',DB_USER,DB_PASS);
	
	# Leer items (READ)
	$read = $db->prepare("
    	SELECT 	item_id, item_name, item_done, item_created
		FROM 	items
		WHERE	user_id =:user
	");
    
    # Lectura global	
    $read->execute(['user' => $_SESSION['user_id']]);
    $items = $read->rowCount() ? $read : [];
    
    
    # Insertar items (CREATE)
    $insert = $db->prepare("
    	INSERT INTO items(user_id,item_name,item_done,item_created) 
    	VALUES(:user,:name,0,NOW())
    ");
    
    #Modificar items (UPDATE)
    $update = $db->prepare("
		UPDATE 	items 
		SET		item_done = 1
		WHERE	item_id = :id
		AND		user_id = :user
	");
	
	#Eliminar tareas (DELETE)
	$delete = $db->prepare("
		DELETE FROM	items
		WHERE		item_id = :id
		AND			user_id = :user
	");
	
	$count = $db->prepare("SELECT COUNT(*) FROM items WHERE item_done = 0");
	$count->execute();
	$number = $count->fetchColumn();
?>

