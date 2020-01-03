package serpis.ad;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class HibernateMain {

	public static void main(String[] args) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.gpedido");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		nuevoPedido(entityManager);

		List<Pedido> pedidos = entityManager.createQuery("from Pedido order by Id", Pedido.class).getResultList();
		show(pedidos);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
		entityManagerFactory.close();
	}
	
	private static void nuevoPedido(EntityManager entityManager) {
		Cliente cliente = entityManager.find(Cliente.class, 1L);
		Pedido pedido = new Pedido(cliente);
		PedidoLinea pedidoLinea1 = new PedidoLinea(pedido);
		Articulo articulo1 = entityManager.find(Articulo.class, 1L);
		pedidoLinea1.setArticulo(articulo1);
		pedidoLinea1.setUnidades(new BigDecimal(4));
		PedidoLinea pedidoLinea2 = new PedidoLinea(pedido);
		Articulo articulo2 = entityManager.find(Articulo.class, 2L);
		pedidoLinea2.setArticulo(articulo2);
		pedidoLinea2.setUnidades(new BigDecimal(5));
		entityManager.persist(pedido);
	}

	private static void show(List<Pedido> pedidos) {
		for (Pedido pedido : pedidos)
			System.out.printf("%3d %s %s %s %n", pedido.getId(), pedido.getFecha(), pedido.getCliente().getNombre(), pedido.getImporte());		
	}
}
