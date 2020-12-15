/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Wpf.Client.Model
*文件名称   ：RoomDeviceModel.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/12/8 星期二 12:19:59 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/12/8 星期二 12:19:59 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using JControl.Base.BLL;
using JControl.Wpf.Client.Views;
using System.Collections.ObjectModel;

namespace JControl.Wpf.Client.Model
{
    public class ProductModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Ctor

        public ProductModel(Base.DTO.ProductDTO dto)
        {
            IsEdit = true;
            LoadProuctDto(dto);
        }

        public ProductModel()
        {
            IsEdit = false;
        }
        
        #endregion

        #region Fields

        private int _Id = 0;
        private string _Name = string.Empty;
        private string _Brand = string.Empty;
        private string _Model = string.Empty;
        private string _Cateory = string.Empty;
        private string _Origin = string.Empty;
        private string _Description = string.Empty;
        private string _Remark = string.Empty;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Id"));
                }

            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }

            }
        }
        public string Brand
        {
            get { return _Brand; }
            set
            {
                _Brand = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Brand"));
                }

            }
        }
        public string Model
        {
            get { return _Model; }
            set
            {
                _Model = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Model"));
                }

            }
        }
        public string Cateory
        {
            get { return _Cateory; }
            set
            {
                _Cateory = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Cateory"));
                }

            }
        }
        public string Origin
        {
            get { return _Origin; }
            set
            {
                _Origin = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Origin"));
                }

            }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Description"));
                }

            }
        }
        public string Remark
        {
            get { return _Remark; }
            set
            {
                _Remark = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Remark"));
                }

            }
        }

        private ObservableCollection<ProductPortModel> _ProductPorts ;
        private ObservableCollection<PortCateoryModel> _PortCateories;

        public ObservableCollection<ProductPortModel> ProductPorts
        {
            get { return _ProductPorts; }
            set
            {
                _ProductPorts = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductPorts"));

            }
        }
        public ObservableCollection<PortCateoryModel> PortCateories
        {
            set
            {
                _PortCateories = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortCateories"));
            }

            get 
            {
                if (_PortCateories == null)
                {
                    _PortCateories = ProductProvider.GetPortCateories();
                }
                return _PortCateories;
            }
            
        }


        private ObservableCollection<PortInputModel> _PortInputs = new ObservableCollection<PortInputModel>();

        public ObservableCollection<PortInputModel> PortInputs
        {
            get { return _PortInputs; }
            set
            {
                _PortInputs = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PortInputs"));
                }

            }
        }



        #endregion

        #region Properties

        public bool IsEdit { get; private set; } = false;

        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                }

            }
        }
        
        #endregion

        #region Private Methods

        private void LoadProuctDto(Base.DTO.ProductDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Brand = dto.Brand;
            Model = dto.Model;
            Origin = dto.Origin;
            Cateory = dto.Cateory;
            Description = dto.Description;
            Remark = dto.Remark;

            if (ProductPorts == null)
                ProductPorts = new ObservableCollection<ProductPortModel>();
            
            foreach (var p in dto.ProductPorts)
            {
                ProductPorts.Add(new ProductPortModel(p));
            }

            _dto = dto;

        }


        private Base.DTO.ProductDTO _dto;
        public Base.DTO.ProductDTO Dto
        {

            get
            {
                if (_dto == null)
                    _dto = new Base.DTO.ProductDTO();
                _dto.Id = Id;
                _dto.Name = Name;
                _dto.Brand = Brand;
                _dto.Model = Model;
                _dto.Origin = Origin;
                _dto.Cateory = Cateory;
                _dto.Description = Description;
                _dto.Remark = Remark;

                return _dto;
            }
        }


       

        private List<Base.DTO.ProductPortDTO> CreateProductPortsDto()
        {
            List<Base.DTO.ProductPortDTO> resultDto = null ;

            if (PortInputs.Count == 0)
                return new List<Base.DTO.ProductPortDTO>();

            if (IsEdit && _dto.ProductPorts.Count > 0)
            {
                
                foreach (var input in PortInputs)
                {
                    var temp = _dto.ProductPorts.Where(x => x
                                .PortCateoryId ==
                                    input.PortCateory.Id)
                                .OrderBy(y=>y.PortKey)
                                .ToList();
                    var offset = input.PortCount - temp.Count;
                    //如果减少
                    if (offset<0)
                    {
                        
                        int start = temp.Count + offset;
                        for (int i = start; i < temp.Count; i++)
                        {
                            _dto.ProductPorts.Remove(temp[i]);
                        }
                    }
                    //如果增加
                    else if (offset>0)
                    {
                        if(resultDto==null)
                            resultDto = new List<Base.DTO.ProductPortDTO>();

                        var index = _dto.ProductPorts.Where(x => x.PortCateoryId == input.PortCateory.Id).Count();
                        var dto = input.PortCateory.Dto;
                            var count = input.PortCount;


                            for (int i = index; i < count; i++)
                            {
                                _dto.ProductPorts.Add(new Base.DTO.ProductPortDTO
                                {
                                    ParentProduct = _dto,
                                    PortCateoryId = dto.Id,
                                    PortName = $"{dto.Name}#{index + 1}",
                                    PortKey = $"{dto.Code}-{index + 1}"
                                });
                            }
                        
                    }
                }
                
                return _dto.ProductPorts.ToList();

                
            }
            else
            {
                resultDto  = new List<Base.DTO.ProductPortDTO>();
                foreach (var input in PortInputs)
                {
                    var dto = input.PortCateory.Dto;
                    var count = input.PortCount;

                
                    for (int i = 0; i < count; i++)
                    {
                        resultDto.Add(new Base.DTO.ProductPortDTO
                        {
                            ParentProduct = _dto,
                            PortCateoryId = dto.Id,
                            PortName = $"{dto.Name}#{i+1}",
                            PortKey = $"{dto.Code}-{i + 1}"
                        });
                    }
                }
            
            }



            return resultDto;
        }


        
        #endregion

        #region Command

        private RelayCommand _EditCommand;
        private RelayCommand _DeleteCommand;

        private RelayCommand _AddPortCommand;
        
        private RelayCommand _SaveCommand;
        private RelayCommand _CancelCommand;

        /// <summary>
        /// 保存事件.
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                return _SaveCommand
                    ?? (_SaveCommand = new RelayCommand(
                    () =>
                    {
                        //数据验证

                        var query = PortInputs.GroupBy(x => x.PortCateory)
                          .Where(g => g.Count() > 1)
                          .Select(y => y.Key)
                          .ToList();

                        if (query.Count > 0)
                        {
                            System.Windows.Forms.MessageBox.Show("数据中不能有相同的接口");
                            return;
                        }

                        if (this.Name == string.Empty || this.Model == string.Empty || this.Brand == string.Empty || this.Origin == string.Empty || this.Cateory == string.Empty)
                        {
                            System.Windows.Forms.MessageBox.Show("数据中不为空");
                            return;
                        }

                        if (IsEdit == false)
                        {
                            var dto = this.Dto;
                            dto.ProductPorts = CreateProductPortsDto();
                            ProductProvider.SaveDtoAndCloseAsync(dto);
                        }
                        
                        else
                        { 
                        

                        var oldDto = this._dto.Clone() as Base.DTO.ProductDTO;
                        oldDto.ProductPorts = new List<Base.DTO.ProductPortDTO>(oldDto.ProductPorts);


                        var newDto = this._dto.Clone() as Base.DTO.ProductDTO;
                        newDto.ProductPorts = CreateProductPortsDto();

                        //Todo
                        ProductProvider.SaveDtoAndCloseAsync(oldDto, newDto);

                        }

                       
                    }));
            }
        }

        /// <summary>
        /// 取消保存事件.
        /// </summary>
        public RelayCommand CancelCommand
        {
            get
            {
                return _CancelCommand
                    ?? (_CancelCommand = new RelayCommand(
                    () =>
                    {
                        GlobalViewHelper.CloseDialog();

                    }));
            }
        }

        /// <summary>
        /// 删除产品事件
        /// </summary>
        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand
                    ?? (_DeleteCommand = new RelayCommand(
                    () =>
                    {
                        /// 删除一个产品
                        ProductProvider.DeleteProduct(this.Id);

                    }));
            }
        }


        /// <summary>
        /// 产品编辑事件.
        /// </summary>
        public RelayCommand EditCommand
        {
            get
            {
                return _EditCommand
                    ?? (_EditCommand = new RelayCommand(
                    () =>
                    {
                        PortInputs = ProductProvider.LoadPortInputs(this, ProductPorts);
                        ProductProvider.ShowEditProduct(this);
                  
                    }));
            }
        }


        /// <summary>
        /// 添加端口事件
        /// </summary>
        public RelayCommand AddPortCommand
        {
            get
            {
                return _AddPortCommand
                    ?? (_AddPortCommand = new RelayCommand(
                    () =>
                    {
                        PortInputs.Add(new PortInputModel(this));

                    }));
            }
        }

        #endregion
        
    }
}
