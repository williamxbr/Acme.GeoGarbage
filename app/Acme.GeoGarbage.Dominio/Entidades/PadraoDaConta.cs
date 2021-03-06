///////////////////////////////////////////////////////////
//  PadroesDaConta.cs
//  Implementation of the Class PadroesDaConta
//  Generated by Enterprise Architect
//  Created on:      20-abr-2017 13:10:17
//  Original author: silas
///////////////////////////////////////////////////////////


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.GeoGarbage.Dominio.Entidades {
	/// <summary>
	/// Configuracoes de conta de um usu?rio.
	/// </summary>
	public class PadraoDaConta {
        public Guid IdUsuario { get; set; }

		/// <summary>
		/// Usuario vinculado ao padr?o
		/// </summary>
		public virtual Usuario Usuario{
			get;
			set;
		}

		/// <summary>
		/// Valor informado em minutos.
		/// O ping ser? considerado verde quando o ?ltimo ping for inferior ao valor
		/// informado neste atributo.
		/// </summary>
		public int PingVerde{
			get;
			set;
		}

		/// <summary>
		/// Valor informado em minutos.
		/// O ping ser? considerado amarelo quando o ?ltimo ping for superior ao valor
		/// informado neste atributo.
		/// </summary>
		public int PingAmarelo{
			get;
			set;
		}

		/// <summary>
		/// Valor informado em minutos.
		/// O ping ser? considerado vermelho quando o ?ltimo ping for superior ao valor
		/// informado neste atributo.
		/// </summary>
		public int PingVermelho{
			get;
			set;
		}

	}//end PadroesDaConta

}//end namespace Entidades