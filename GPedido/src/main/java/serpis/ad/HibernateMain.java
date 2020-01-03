package serpis.ad;

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
		
//		List<Categoria> categorias = entityManager.createQuery("from Categoria order by Id", Categoria.class).getResultList();
//		show(categorias);

//		List<Articulo> articulos = entityManager.createQuery("from Articulo order by Id", Articulo.class).getResultList();
//		show(articulos);

//		List<Cliente> clientes = entityManager.createQuery("from Cliente order by Id", Cliente.class).getResultList();
//		show(clientes);

		entityManager.getTransaction().commit();
		entityManager.close();
		
		
		entityManagerFactory.close();

	}
	
//	private static void show(List<Categoria> categorias) {
//		for (Categoria categoria : categorias)
//			System.out.printf("%3d %s %n", categoria.getId(), categoria.getNombre());		
//	}

//	private static void show(List<Articulo> articulos) {
//		for (Articulo articulo : articulos)
//			System.out.printf("%3d %s %s %s %n", articulo.getId(), articulo.getNombre(), articulo.getPrecio(), articulo.getCategoria().getNombre());		
//	}

//	private static void show(List<Cliente> clientes) {
//		for (Cliente cliente : clientes)
//			System.out.printf("%3d %s %n", cliente.getId(), cliente.getNombre());		
//	}

}
