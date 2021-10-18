<?php
	require_once 'app/init.php';
	require_once 'app/database.php';
	
    if(!isset($page_title)){$page_title='Introducción a PHP';}

	/*
    foreach($items as $item){
    	print_r($item);
    }
    */
?>
<!DOCTYPE html>
<html lang="es">
	<head>
		<meta charsert="UTF-8"/>	
		<title><?php echo $page_title;?></title>
		<link rel="stylesheet" type="text/css" href="css/animate.css"/>
		<link rel="stylesheet" type="text/css" href="css/main.css"/>
		<meta name="viewport" content="width=device-width, initial-scale=1"/> 
		<script src="https://kit.fontawesome.com/80c5e8c10f.js" crossorigin="anonymous"></script>
	</head>
	<body>
		<section id="list">
			<h1><i class="fas fa-clipboard-list"></i> ToDo List</h1>

			<!-- BLOQUE DINÁMICO DE LA APP-->
			<!-- TAREAS PENDIENTES -->
			<p id="tasks" class="animated heartBeat"><?php echo $number;?></p>

			<!-- LISTA DE ITEMS DINÁMICA -->
			<?php if(!empty($items)): ?>
			<ul class="items animated zoomIn">
				<?php foreach($items as $item):?>
					<li>
						
						<?php if(!$item['item_done']):?>
							<a href="update.php?as=done&id=<?php echo $item['item_id'];?>" class="done-button"><i class="fas fa-check-square fa-lg"></i></a>
						<?php endif;?>
						
						<a href="delete.php?as=del&id=<?php echo $item['item_id'];?>" class="delete-button"><i class="fas fa-trash-alt fa-lg"></i></a>
						
						<span class="item <?php echo $item['item_done']? ' done':''; ?>">
							<?php echo $item['item_name'];?>
						</span>

						<!-- FECHAS -->
						<span class="dates">
							<?php echo $item['item_created'];?>
						</span>	
					</li>
				<?php endforeach;?>
			</ul>
			<?php else: ?>
				<p class="warning"><i class="far fa-sad-tear fa-lg"></i> ¡No has añadido ningún item!</p>
			<?php endif; ?>	
			
			<!-- Formulario de ingreso -->
			<form action="add.php" method="post">
				<input type="text" name="name" placeholder="¿Qué deseas hacer?" class="textbox" autocomplete="off" required autofocus/>
				<button type="submit"><i class="fas fa-plus-square fa-lg"></i> &nbsp;Agrega tu item a la lista</button>
			</form>
			<footer>Diseñado y desarrollado por <span class="bold" title="victorcifuentes4@gmail.com">Victor Cifuentes con ayuda de Allan Ruíz</span>, para fines educativos únicamente. @2021</footer>
		</section>
	</body>
</html>