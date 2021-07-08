import BaseApi from "./BaseApi";
export default  class TaskApi extends  BaseApi{
  constructor(){
    super("Task");
  }
  /**
   * 离散数据调用接口Url
   * @type {string}
   */
  GetDiscreteListUrl="/api/Task/GetDiscreteList";
  /**
  * 获取离散数据
  * @param parms
  * @returns {Promise<void>}
  */
  async GetDiscreteList(parms)
  {
    return await this._http.POST(this.GetDiscreteListUrl,parms);
  }
  /**
   * 创建多任务
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
  SetCreateTasksListUrl="/api/Task/CreateTasks";
  async SetTasksList(parms)
  {
    return await this._http.POST(this.SetCreateTasksListUrl,parms);
  }
  /**
   * 批号获取任务列表
   */
  GetTaskByBatchListUrl="/api/Task/getTaskByBatch";
  async GetTaskByBatchList(parms)
  {
    return await this._http.GET(this.GetTaskByBatchListUrl,parms);
  }

  /**
   * 上传excel接口
   * @type {string}
   */
  uploadExcelUrl="/api/Task/uploadExcel";
  async uploadExcel(parms)
  {
      return await this._http.POST(this.uploadExcelUrl,parms);
  }

  /**
   * 导入离散数据
   * @type {string}
   */
  ImportDimensionDataUrl="/api/Task/ImportDimensionData";
  async importDimensionData(parms)
  {
    return await this._http.POST(this.ImportDimensionDataUrl,parms);
  }
  /**
   * 根据批号删除任务
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
  deleteBatchNoApiUrl ="/api/Task/deleteTaskByBatch";
  async deleteBatchNoList(parms){
    return await this._http.GET(this.deleteBatchNoApiUrl,parms);
   }
   /**
   * 根据批号获取汇总数据任务
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
  getSummaryApiUrl ="/api/SpcAnalyse/GetHistogramData";
  async GetSummaryList(parms){
    return await this._http.GET(this.getSummaryApiUrl,parms);
   }
   /**
   * 根据测量数据详情数据任务
   * @param parms
   * @returns {Promise<void>}
   * @public
   */
  getDimensionDetailApiUrl ="/api/Task/GetDimensionDetailList";
  async GetDimensionDetailList(parms){
    return await this._http.POST(this.getDimensionDetailApiUrl,parms);
   }

}
