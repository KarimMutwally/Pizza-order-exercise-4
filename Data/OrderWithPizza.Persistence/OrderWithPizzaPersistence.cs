﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWithPizza.Persistence
{
	/// <summary>Static class for (extension) methods for fetching and projecting instances of OrderWithPizza.DtoClasses.OrderWithPizza from the entity model.</summary>
	public static partial class OrderWithPizzaPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<PizzaOrder.EntityClasses.OrderEntity, OrderWithPizza.DtoClasses.OrderWithPizza>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<PizzaOrder.EntityClasses.OrderEntity, OrderWithPizza.DtoClasses.OrderWithPizza> _compiledProjector = CreateProjectionFunc().Compile();
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static OrderWithPizzaPersistence() { }
	
		/// <summary>Extension method which produces a projection to OrderWithPizza.DtoClasses.OrderWithPizza which instances are projected from the 
		/// results of the specified baseQuery, which returns PizzaOrder.EntityClasses.OrderEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve OrderWithPizza.DtoClasses.OrderWithPizza instances</returns>
		public static IQueryable<OrderWithPizza.DtoClasses.OrderWithPizza> ProjectToOrderWithPizza(this IQueryable<PizzaOrder.EntityClasses.OrderEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}
		
		/// <summary>Extension method which produces a projection to OrderWithPizza.DtoClasses.OrderWithPizza which instances are projected from the
		/// PizzaOrder.EntityClasses.OrderEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>PizzaOrder.EntityClasses.OrderEntity instance created from the specified entity instance</returns>
		public static OrderWithPizza.DtoClasses.OrderWithPizza ProjectToOrderWithPizza(this PizzaOrder.EntityClasses.OrderEntity entity)
		{
			return _compiledProjector(entity);
		}
		
		private static System.Linq.Expressions.Expression<Func<PizzaOrder.EntityClasses.OrderEntity, OrderWithPizza.DtoClasses.OrderWithPizza>> CreateProjectionFunc()
		{
			return p__0 => new OrderWithPizza.DtoClasses.OrderWithPizza()
			{
				Name = p__0.Name,
				OrderPizzas = p__0.OrderPizzas.Select(p__1 => new OrderWithPizza.DtoClasses.OrderWithPizzaTypes.OrderPizza()
				{
					OrderId = p__1.OrderId,
					PizzaId = p__1.PizzaId,
					Size = p__1.Size,
				}).ToList(),
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_OrderWithPizza 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
		}
	}
}

