import  * as Http from '../libs/axios';
/**
 * api 基类
 */
export  default  class  BaseApi {
  /**
   * 模块名称
   * @type {string}
   * @protected
   */
  _modelname='';
  /**
   * //获取单条记录 ApiUrl
   * @type {string}
   * @protected
   */
  _getApiUrl='';
  /**
   * 接口 delete url地址
   * @type {string}
   * @protected
   */
  _deleteApiUrl='';
  /**
   * 接口 获取所有记录 url地址
   * @type {string}
   * @protected
   */
  _getallApiUrl='';
  /**
   * 接口 新增url地址
   * @type {string}
   * @protected
   */
  _createApiUrl='';
  /**
   * 接口 修改url地址
   * @type {string}
   * @protected
   */
  _updateApiUrl='';
  /**
   *请求句柄
   * @type {{DELETE?, GET?, POST?, PUT?, PATCH?}}
   * @protected
   */
  _http=Http;
  /**
   * API基类构造函数
   * @param modelname 模块名称
   */
   constructor(modelname)
   {
     this._modelname=modelname;
     this._getApiUrl="/api/"+modelname+"/Get"+modelname+"ByID";
     this._createApiUrl="/api/"+modelname+"/Create"+modelname;
     this._updateApiUrl="/api/"+modelname+"/Update"+modelname;
     this._getallApiUrl="/api/"+modelname+"/Get"+modelname+"ListForPagination";
     this._deleteApiUrl="/api/"+modelname+"/Delete"+modelname;
   }

  /**
   * 获取单条数据
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
    async  get(parms){
       return await Http.GET(this._getApiUrl,parms);
    }

  /**
   * 取多条数据
   * @param parms
   * @returns {Promise<void>}
   * @public
   */

     async getAll(parms){
      return await  Http.POST(this._getallApiUrl,parms);
    }

  /**
   * 新增
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
    async create(parms){
      return await  Http.POST(this._createApiUrl,parms);
    }

  /**
   * 修改
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
    async update(parms){
      return await  Http.POST(this._updateApiUrl,parms);
    }

  /**
   * 删除
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
    async delete(parms){
     return await  Http.GET(this._deleteApiUrl,parms);
    }
}
