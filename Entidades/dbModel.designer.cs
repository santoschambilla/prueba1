﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
    using System.Configuration;
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="bdbiblio")]
	public partial class dbModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void Insertautor(autor instance);
    partial void Updateautor(autor instance);
    partial void Deleteautor(autor instance);
    partial void Insertlibro(libro instance);
    partial void Updatelibro(libro instance);
    partial void Deletelibro(libro instance);
    partial void Insertautor_libro(autor_libro instance);
    partial void Updateautor_libro(autor_libro instance);
    partial void Deleteautor_libro(autor_libro instance);
    #endregion
		
		public dbModelDataContext() : 
				base(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString())
        {
            OnCreated();
        }
		
		
		
		public System.Data.Linq.Table<autor> autor
		{
			get
			{
				return this.GetTable<autor>();
			}
		}
		
		public System.Data.Linq.Table<libro> libro
		{
			get
			{
				return this.GetTable<libro>();
			}
		}
		
		public System.Data.Linq.Table<autor_libro> autor_libro
		{
			get
			{
				return this.GetTable<autor_libro>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.autor")]
	public partial class autor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_autor;
		
		private string _nombre;
		
		private EntitySet<autor_libro> _autor_libro;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_autorChanging(int value);
    partial void Onid_autorChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    #endregion
		
		public autor()
		{
			this._autor_libro = new EntitySet<autor_libro>(new Action<autor_libro>(this.attach_autor_libro), new Action<autor_libro>(this.detach_autor_libro));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_autor", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_autor
		{
			get
			{
				return this._id_autor;
			}
			set
			{
				if ((this._id_autor != value))
				{
					this.Onid_autorChanging(value);
					this.SendPropertyChanging();
					this._id_autor = value;
					this.SendPropertyChanged("id_autor");
					this.Onid_autorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="VarChar(100)")]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="autor_autor_libro", Storage="_autor_libro", ThisKey="id_autor", OtherKey="id_autor")]
		public EntitySet<autor_libro> autor_libro
		{
			get
			{
				return this._autor_libro;
			}
			set
			{
				this._autor_libro.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_autor_libro(autor_libro entity)
		{
			this.SendPropertyChanging();
			entity.autor = this;
		}
		
		private void detach_autor_libro(autor_libro entity)
		{
			this.SendPropertyChanging();
			entity.autor = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.libro")]
	public partial class libro : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_libro;
		
		private string _titulo;
		
		private System.Nullable<System.DateTime> _fecha;
		
		private EntitySet<autor_libro> _autor_libro;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_libroChanging(int value);
    partial void Onid_libroChanged();
    partial void OntituloChanging(string value);
    partial void OntituloChanged();
    partial void OnfechaChanging(System.Nullable<System.DateTime> value);
    partial void OnfechaChanged();
    #endregion
		
		public libro()
		{
			this._autor_libro = new EntitySet<autor_libro>(new Action<autor_libro>(this.attach_autor_libro), new Action<autor_libro>(this.detach_autor_libro));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_libro", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_libro
		{
			get
			{
				return this._id_libro;
			}
			set
			{
				if ((this._id_libro != value))
				{
					this.Onid_libroChanging(value);
					this.SendPropertyChanging();
					this._id_libro = value;
					this.SendPropertyChanged("id_libro");
					this.Onid_libroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_titulo", DbType="VarChar(150)")]
		public string titulo
		{
			get
			{
				return this._titulo;
			}
			set
			{
				if ((this._titulo != value))
				{
					this.OntituloChanging(value);
					this.SendPropertyChanging();
					this._titulo = value;
					this.SendPropertyChanged("titulo");
					this.OntituloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha", DbType="Date")]
		public System.Nullable<System.DateTime> fecha
		{
			get
			{
				return this._fecha;
			}
			set
			{
				if ((this._fecha != value))
				{
					this.OnfechaChanging(value);
					this.SendPropertyChanging();
					this._fecha = value;
					this.SendPropertyChanged("fecha");
					this.OnfechaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="libro_autor_libro", Storage="_autor_libro", ThisKey="id_libro", OtherKey="id_libro")]
		public EntitySet<autor_libro> autor_libro
		{
			get
			{
				return this._autor_libro;
			}
			set
			{
				this._autor_libro.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_autor_libro(autor_libro entity)
		{
			this.SendPropertyChanging();
			entity.libro = this;
		}
		
		private void detach_autor_libro(autor_libro entity)
		{
			this.SendPropertyChanging();
			entity.libro = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.autor_libro")]
	public partial class autor_libro : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idautorlibro;
		
		private System.Nullable<int> _id_autor;
		
		private System.Nullable<int> _id_libro;
		
		private EntityRef<autor> _autor;
		
		private EntityRef<libro> _libro;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidautorlibroChanging(int value);
    partial void OnidautorlibroChanged();
    partial void Onid_autorChanging(System.Nullable<int> value);
    partial void Onid_autorChanged();
    partial void Onid_libroChanging(System.Nullable<int> value);
    partial void Onid_libroChanged();
    #endregion
		
		public autor_libro()
		{
			this._autor = default(EntityRef<autor>);
			this._libro = default(EntityRef<libro>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idautorlibro", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idautorlibro
		{
			get
			{
				return this._idautorlibro;
			}
			set
			{
				if ((this._idautorlibro != value))
				{
					this.OnidautorlibroChanging(value);
					this.SendPropertyChanging();
					this._idautorlibro = value;
					this.SendPropertyChanged("idautorlibro");
					this.OnidautorlibroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_autor", DbType="Int")]
		public System.Nullable<int> id_autor
		{
			get
			{
				return this._id_autor;
			}
			set
			{
				if ((this._id_autor != value))
				{
					if (this._autor.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_autorChanging(value);
					this.SendPropertyChanging();
					this._id_autor = value;
					this.SendPropertyChanged("id_autor");
					this.Onid_autorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_libro", DbType="Int")]
		public System.Nullable<int> id_libro
		{
			get
			{
				return this._id_libro;
			}
			set
			{
				if ((this._id_libro != value))
				{
					if (this._libro.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_libroChanging(value);
					this.SendPropertyChanging();
					this._id_libro = value;
					this.SendPropertyChanged("id_libro");
					this.Onid_libroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="autor_autor_libro", Storage="_autor", ThisKey="id_autor", OtherKey="id_autor", IsForeignKey=true)]
		public autor autor
		{
			get
			{
				return this._autor.Entity;
			}
			set
			{
				autor previousValue = this._autor.Entity;
				if (((previousValue != value) 
							|| (this._autor.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._autor.Entity = null;
						previousValue.autor_libro.Remove(this);
					}
					this._autor.Entity = value;
					if ((value != null))
					{
						value.autor_libro.Add(this);
						this._id_autor = value.id_autor;
					}
					else
					{
						this._id_autor = default(Nullable<int>);
					}
					this.SendPropertyChanged("autor");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="libro_autor_libro", Storage="_libro", ThisKey="id_libro", OtherKey="id_libro", IsForeignKey=true)]
		public libro libro
		{
			get
			{
				return this._libro.Entity;
			}
			set
			{
				libro previousValue = this._libro.Entity;
				if (((previousValue != value) 
							|| (this._libro.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._libro.Entity = null;
						previousValue.autor_libro.Remove(this);
					}
					this._libro.Entity = value;
					if ((value != null))
					{
						value.autor_libro.Add(this);
						this._id_libro = value.id_libro;
					}
					else
					{
						this._id_libro = default(Nullable<int>);
					}
					this.SendPropertyChanged("libro");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
