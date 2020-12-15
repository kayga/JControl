using JControl.Base.Dal;
using JControl.Base.DTO;
using JControl.Base.IDal;
using JControl.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Base.BLL
{
    public class ProductManager : BaseManager,IProductManager
    {
        public async Task<List<DTO.ProductDTO>> GetProducts()
        {
            using (IProductService devSvc = new ProductService())
            {
                return await Task.Run(() =>
                {
                    return devSvc.GetProductIncludePorts()
                                    .Select(m => new DTO.ProductDTO
                                    {
                                        Id = m.Id,
                                        Brand = m.Brand,
                                        Cateory = m.Cateory,
                                        Model = m.Model,
                                        Name = m.Name,
                                        Origin = m.Origin,
                                        Description = m.Description,
                                        Remark = m.Remark
                                    }).ToList();
                });                
            }
        }
        public async Task<int> AddAsync(ProductDTO dto)
        {
            using (IProductService rdevSvc = new ProductService())
            {
                var model = ConvserToEntity(dto);

                   
                //model.Cateory = ObjectExtend.Mapper<CateoryEntity, CateoryDTO>(dto.Cateory);
                //model.CateoryId = dto.Cateory.Id;

                return await Task.Run(() =>
                {
                    return rdevSvc.AddConnChildAsync(model);
                });
            }
            

        }

        public async Task<int> EditAsync(ProductDTO dto)
        {
            var model = ConvserToEntity(dto);

            using (IProductService rdevSvc = new ProductService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.EditAsync(model);
                });
            }
        }
        public async Task<int> EditAsync(ProductDTO oldDto,ProductDTO newDto)
        {
            var oModel = ConvserToEntity(oldDto);
            var nModel = ConvserToEntity(newDto);
        

            using (IProductService svc = new ProductService())
            {
                return await Task.Run(() =>
                {
                    return svc.EditProductAsync(nModel,oModel);
                });
            }
        }



        public async Task<int> DeleteAsync(int id)
        {
            using (IProductService rdevSvc = new ProductService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.DeleteAsync(id);
                });
            }

        }
        public async Task<int> RealDeleteAsync(int id)
        {
            using (IProductService rdevSvc = new ProductService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.RealDeleteAsync(id);
                });
            }

        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            using (IProductService rdevSvc = new ProductService())
            {
                var items = await Task.Run(() =>
                {
                    return rdevSvc.GetProductIncludePorts()
                                    .ToList()
                                    .ConvertAll(x => 
                                       ObjectExtend.Mapper<ProductDTO, ProductEntity>(x)
                                       );
                });

                //CateoryManager cateoryManager = new CateoryManager();
                //foreach (var i in items)
                //    i.Cateory =await cateoryManager.GetOneAsync(i.CateoryId);
              
                return items;
            }
        }

        public async Task<ProductDTO> GetOneAsync(int id)
        {
            using (IProductService rdevSvc = new ProductService())
            {
                return await Task.Run(() =>
                {
                    return ObjectExtend.Mapper<ProductDTO, ProductEntity>(rdevSvc.GetOneAsync(id).Result);

                });
            }
        }


        public async Task<List<ProductDTO>> GetAllByPageAsync(int pageSize, int pageIndex, Expression<Func<ProductDTO, bool>> whereLambda, bool isAsc)
        {
            var dtoExp = whereLambda;
            Expression<Func<ProductEntity, bool>> entityExp = null;
            entityExp = dtoExp.Cast<ProductDTO, ProductEntity>();
           
            #region Sample1


            //using (IProductService rdevSvc = new ProductService())
            //{
            //    var items = await Task.Run(() =>
            //    {
            //        return rdevSvc.QueryByPage(pageSize,pageIndex, entityExp, isAsc)
            //                        .ToList()
            //                        .ConvertAll(x =>
            //                           ObjectExtend.Mapper<ProductDTO, ProductEntity>(x)
            //                           );
            //    });
            //    return items;
            //}
            #endregion


            using (IProductService svc = new ProductService())
            {

                var items = await Task.Run(() =>
                {
                    return svc.GetProductIncludePortsByPage(pageSize, pageIndex, entityExp, isAsc)
                                    .ToList()
                                    .ConvertAll(x => new DTO.ProductDTO(x)
                                    );

                });
                return items;
            }
        }


        public ProductEntity ConvserToEntity(ProductDTO dto)
        {
            var result = ObjectExtend.Mapper<ProductEntity, ProductDTO>(dto);
            int i = 0;
            foreach (var p in dto.ProductPorts)
            {
                result.ProductPorts.Add(ObjectExtend.Mapper<ProductPortEntity, ProductPortDTO>(p));
                result.ProductPorts[i].ParentProduct = result;
                //result.ProductPorts[i].PortCateory = ObjectExtend.Mapper<PortCateoryEntity,PortCateoryDTO>(p.PortCateory);
                
                i++;
            }

            return result;
        }

        
    }
    public static class LambdaExpressionExtensions
    {
        private static Expression Parser(ParameterExpression parameter, Expression expression)
        {
            if (expression == null) return null;
            switch (expression.NodeType)
            {
                //一元运算符
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                    {
                        var unary = expression as UnaryExpression;
                        var exp = Parser(parameter, unary.Operand);
                        return Expression.MakeUnary(expression.NodeType, exp, unary.Type, unary.Method);
                    }
                //二元运算符
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                    {
                        var binary = expression as BinaryExpression;
                        var left = Parser(parameter, binary.Left);
                        var right = Parser(parameter, binary.Right);
                        var conversion = Parser(parameter, binary.Conversion);
                        if (binary.NodeType == ExpressionType.Coalesce && binary.Conversion != null)
                        {
                            return Expression.Coalesce(left, right, conversion as LambdaExpression);
                        }
                        else
                        {
                            return Expression.MakeBinary(expression.NodeType, left, right, binary.IsLiftedToNull, binary.Method);
                        }
                    }
                //其他
                case ExpressionType.Call:
                    {
                        var call = expression as MethodCallExpression;
                        List<Expression> arguments = new List<Expression>();
                        foreach (var argument in call.Arguments)
                        {
                            arguments.Add(Parser(parameter, argument));
                        }
                        var instance = Parser(parameter, call.Object);
                        call = Expression.Call(instance, call.Method, arguments);
                        return call;
                    }
                case ExpressionType.Lambda:
                    {
                        var Lambda = expression as LambdaExpression;
                        return Parser(parameter, Lambda.Body);
                    }
                case ExpressionType.MemberAccess:
                    {
                        var memberAccess = expression as MemberExpression;
                        if (memberAccess.Expression == null)
                        {
                            memberAccess = Expression.MakeMemberAccess(null, memberAccess.Member);
                        }
                        else
                        {
                            var exp = Parser(parameter, memberAccess.Expression);
                            var member = exp.Type.GetMember(memberAccess.Member.Name).FirstOrDefault();
                            memberAccess = Expression.MakeMemberAccess(exp, member);
                        }
                        return memberAccess;
                    }
                case ExpressionType.Parameter:
                    return parameter;
                case ExpressionType.Constant:
                    return expression;
                case ExpressionType.TypeIs:
                    {
                        var typeis = expression as TypeBinaryExpression;
                        var exp = Parser(parameter, typeis.Expression);
                        return Expression.TypeIs(exp, typeis.TypeOperand);
                    }
                default:
                    throw new Exception(string.Format("Unhandled expression type: '{0}'", expression.NodeType));
            }
        }
        public static Expression<Func<TToProperty, bool>> Cast<TInput, TToProperty>(this Expression<Func<TInput, bool>> expression)
        {
            var p = Expression.Parameter(typeof(TToProperty), "p");
            var x = Parser(p, expression);
            return Expression.Lambda<Func<TToProperty, bool>>(x, p);
        }
    }
}
