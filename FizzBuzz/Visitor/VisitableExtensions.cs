using System;
using JetBrains.Annotations;
using Microsoft.CSharp.RuntimeBinder;

namespace FizzBuzz.Visitor
{
  public static class VisitableExtensions
  {
    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a Visitor.
    /// </summary>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitor">The visitor used to visit the objects.</param>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in the provided <paramref name="visitor" /> and the visitor was configured to rethrow the
    ///   exception.
    /// </exception>
    [PublicAPI]
    public static void Accept(this IVisitableExtensionPoint<object> visitable,
                              [NotNull] Visitor visitor)
    {
      try
      {
        ((dynamic) visitor).Visit((dynamic) visitable.ExtendedValue);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitor.Rethrow)
        {
          throw;
        }
        visitor.Fallback(visitable.ExtendedValue, runtimeBinderException);
      }
    }

    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a Visitor and an extra parameter.
    /// </summary>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitor">The visitor used to visit the objects.</param>
    /// <param name="parameter1">The extra parameter.</param>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in the provided <paramref name="visitor" /> and the visitor was configured to rethrow the
    ///   exception.
    /// </exception>
    [PublicAPI]
    public static void Accept(this IVisitableExtensionPoint<object> visitable,
                              [NotNull] Visitor visitor,
                              object parameter1)
    {
      try
      {
        ((dynamic) visitor).Visit((dynamic) visitable.ExtendedValue, (dynamic) parameter1);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitor.Rethrow)
        {
          throw;
        }
        visitor.Fallback(visitable.ExtendedValue, runtimeBinderException, parameter1);
      }
    }


    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a Visitor and two extra parameter.
    /// </summary>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitor">The visitor used to visit the objects.</param>
    /// <param name="parameter1">The extra parameter.</param>
    /// <param name="parameter2">Second extra parameter.</param>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in the provided <paramref name="visitor" /> and the visitor was configured to rethrow the
    ///   exception.
    /// </exception>
    [PublicAPI]
    public static void Accept(this IVisitableExtensionPoint<object> visitable,
                              [NotNull] Visitor visitor,
                              object parameter1,
                              object parameter2)
    {
      try
      {
        ((dynamic) visitor).Visit((dynamic) visitable.ExtendedValue, (dynamic) parameter1, (dynamic) parameter2);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitor.Rethrow)
        {
          throw;
        }
        visitor.Fallback(visitable.ExtendedValue, runtimeBinderException, parameter1, parameter2);
      }
    }

    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a VisitorFactory and produce
    ///   an object from the visitation of another.
    /// </summary>
    /// <typeparam name="TResult">The type of object produced by visitation.</typeparam>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitorFactory">The visitor factory used to create the objects.</param>
    /// <returns>
    ///   If <paramref name="visitorFactory" /> contains a Visit method whose signature contains a single
    ///   parameter of the the type of object to visit, it will be called dynamically to produce the desired object.
    ///   If no such method exists in the <paramref name="visitorFactory" />, this method will throw an exception or
    ///   return a default object depending on how the factory was configured.
    /// </returns>
    /// <exception cref="System.InvalidCastException">
    ///   Failed to cast the object created by the <paramref name="visitorFactory" /> to the type produced by this
    ///   method and the factory was configured to rethrow the exception.
    /// </exception>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in the provided <paramref name="visitorFactory" /> and the factory was
    ///   configured to rethrow the exception.
    /// </exception>
    [PublicAPI]
    public static TResult Accept<TResult>(this IVisitableExtensionPoint<object> visitable,
                                          [NotNull] VisitorFactory visitorFactory)
    {
      try
      {
        dynamic factory = visitorFactory;
        dynamic toVisit = visitable.ExtendedValue;
        TResult result = factory.Visit(toVisit);
        return result;
      }
      catch (InvalidCastException invalidCastException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<TResult>(visitable.ExtendedValue, invalidCastException);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<TResult>(visitable.ExtendedValue, runtimeBinderException);
      }
    }

    public static TResult Accept<TResult>(this IVisitableExtensionPoint<object> visitable,
                                          [NotNull] VisitorFactory<TResult> visitorFactory)
    {
      return Accept<TResult>(visitable, (VisitorFactory) visitorFactory);
    }

    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a VisitorFactory and produce
    ///   an object from the visitation of another by providing an extra parameter.
    /// </summary>
    /// <typeparam name="TResult">The type of object produced by visitation.</typeparam>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitorFactory">The visitor factory used to create the objects.</param>
    /// <param name="parameter1">The extra parameter.</param>
    /// <returns>
    ///   If <paramref name="visitorFactory" /> contains a Visit method whose signature contains one
    ///   parameter of the the type of object to visit and another corresponding to the extra parameter, it will be
    ///   called dynamically to produce the desired object. If no such method exists in the
    ///   <paramref name="visitorFactory" />, this method will throw an exception or return a default object depending
    ///   on how the factory was configured.
    /// </returns>
    /// <exception cref="System.InvalidCastException">
    ///   Failed to cast the object created by the <paramref name="visitorFactory" /> to the type produced by this
    ///   method and the factory was configured to rethrow the exception.
    /// </exception>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in the provided <paramref name="visitorFactory" /> and the factory was
    ///   configured to rethrow the exception.
    /// </exception>
    [PublicAPI]
    public static TResult Accept<TResult>(this IVisitableExtensionPoint<object> visitable,
                                          [NotNull] VisitorFactory visitorFactory,
                                          object parameter1)
    {
      try
      {
        return ((dynamic) visitorFactory).Visit((dynamic) visitable.ExtendedValue, (dynamic) parameter1);
      }
      catch (InvalidCastException invalidCastException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<TResult>(visitable.ExtendedValue, invalidCastException, parameter1);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<TResult>(visitable.ExtendedValue, runtimeBinderException, parameter1);
      }
    }

    public static TResult Accept<TResult>(this IVisitableExtensionPoint<object> visitable,
                                          [NotNull] VisitorFactory<TResult> visitorFactory,
                                          object parameter1)
    {
      return Accept<TResult>(visitable, (VisitorFactory) visitorFactory, parameter1);
    }

    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a VisitorFactory and produce
    ///   an object from the visitation of another by providing two extra parameters.
    /// </summary>
    /// <typeparam name="TResult">The type of object produced by visitation.</typeparam>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitorFactory">The visitor factory used to create the objects.</param>
    /// <param name="parameter1">The first extra parameter.</param>
    /// <param name="parameter2">The second extra parameter.</param>
    /// <returns>
    ///   If <paramref name="visitorFactory" /> contains a Visit method whose signature contains one
    ///   parameter of the the type of object to visit and another corresponding to the extra parameter, it will be
    ///   called dynamically to produce the desired object. If no such method exists in the
    ///   <paramref name="visitorFactory" />, this method will throw an exception or return a default object depending
    ///   on how the factory was configured.
    /// </returns>
    /// <exception cref="System.InvalidCastException">
    ///   Failed to cast the object created by the <paramref name="visitorFactory" /> to the type produced by this
    ///   method and the factory was configured to rethrow the exception.
    /// </exception>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in the provided <paramref name="visitorFactory" /> and the factory was
    ///   configured to rethrow the exception.
    /// </exception>
    [PublicAPI]
    public static TResult Accept<TResult>(this IVisitableExtensionPoint<object> visitable,
                                          [NotNull] VisitorFactory visitorFactory,
                                          object parameter1,
                                          object parameter2)
    {
      try
      {
        return ((dynamic) visitorFactory).Visit((dynamic) visitable.ExtendedValue,
                                                (dynamic) parameter1,
                                                (dynamic) parameter2);
      }
      catch (InvalidCastException invalidCastException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<TResult>(visitable.ExtendedValue,
                                                            invalidCastException,
                                                            parameter1,
                                                            parameter2);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<TResult>(visitable.ExtendedValue,
                                                            runtimeBinderException,
                                                            parameter1,
                                                            parameter2);
      }
    }

    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a VisitorFactory and produce
    ///   an object from the visitation of another by providing three extra parameters.
    /// </summary>
    /// <typeparam name="TResult">The type of object produced by visitation.</typeparam>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitorFactory">The visitor factory used to create the objects.</param>
    /// <param name="parameter1">The first extra parameter.</param>
    /// <param name="parameter2">The second extra parameter.</param>
    /// <param name="parameter3">The third extra parameter.</param>
    /// <returns>
    ///   If <paramref name="visitorFactory" /> contains a Visit method whose signature contains one
    ///   parameter of the the type of object to visit and another corresponding to the extra parameter, it will be
    ///   called dynamically to produce the desired object. If no such method exists in the
    ///   <paramref name="visitorFactory" />, this method will throw an exception or return a default object depending
    ///   on how the factory was configured.
    /// </returns>
    /// <exception cref="System.InvalidCastException">
    ///   Failed to cast the object created by the <paramref name="visitorFactory" /> to the type produced by this
    ///   method and the factory was configured to rethrow the exception.
    /// </exception>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in the provided <paramref name="visitorFactory" /> and the factory was
    ///   configured to rethrow the exception.
    /// </exception>
    [PublicAPI]
    public static TResult Accept<TResult>(this IVisitableExtensionPoint<object> visitable,
                                          [NotNull] VisitorFactory visitorFactory,
                                          object parameter1,
                                          object parameter2,
                                          object parameter3)
    {
      try
      {
        return ((dynamic) visitorFactory).Visit((dynamic) visitable.ExtendedValue,
                                                (dynamic) parameter1,
                                                (dynamic) parameter2,
                                                (dynamic) parameter3);
      }
      catch (InvalidCastException invalidCastException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<TResult>(visitable.ExtendedValue,
                                                            invalidCastException,
                                                            parameter1,
                                                            parameter2,
                                                            parameter3);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<TResult>(visitable.ExtendedValue,
                                                            runtimeBinderException,
                                                            parameter1,
                                                            parameter2,
                                                            parameter3);
      }
    }
  }
}