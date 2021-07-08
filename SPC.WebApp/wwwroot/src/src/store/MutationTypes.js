/**
 * Mutation类型定义
 */
export  default  class MutationTypes {

  /**
   * 设置不良品控制图及比对参数
   * @type {string}
   */
  static SET_BADCHART='SET_BADCHART';
  static SET_CBADCHART='SET_CBADCHART';
  /**
   * 设置良品率报表图
   * @type {string}
   */
  static SET_OKCHART='SET_OKCHART';

  /**
   * 设置不良数据列表
   * @type {string}
   */
  static  SET_BADLIST='SET_BADLIST';
  static SET_CBADLIST='SET_CBADLIST';
  /**
   * 设置柏拉图图数据
   * @type {string}
   */
  static  SET_PSORTCHART='SET_PSORTCHART';
  static SET_CPSORTCHART='SET_CPSORTCHART';
  /**
   * 修改api
   * @type {string}
   */
  static  SET_API='SET_API';
  /**
   * 设置当前登录用户
   * @type {string}
   */
  static  SET_NICKNAME='SET_NICKNAME';
  /**
   * 设置列表数据
   * @type {string}
   */
 static  SET_LISTData='SET_LISTData';
  /**
   * 设置选中记录数据
   * @type {string}
   */
 static  SET_SELECTUSERS='SET_SELECTUSERS';
  /**
   * 编辑FROM
   * @type {string}
   */
 static SET_EDITFORM='SET_EDITFORM';
  /**
   * 编辑比较FROM
   * @type {string}
   */
  static SET_COMPAREFORM='SET_COMPAREFORM';
 // TOP 组件模块
  /**
   * 设置全屏标识状态
   * @type {string}
   */
  static  SET_FULLSCREEN='SET_FULLSCREEN';
  /**
   * 设置菜单收缩标识状态
   * @type {string}
   */
  static  SET_COLLAPSED='SET_COLLAPSED';

  /**
   * 设置菜单选中标识状态
   * @type {string}
   */
  static  SET_DEFAULTACTIVEINDEX='SET_DEFAULTACTIVEINDEX';
  //当前用户
  /**
   *  设置当前用户名
   * @type {string}
   */
  static  SET_CURUSERNAME='SET_USERNAME';
  /**
   * 设置当前用户编号
   * @type {string}
   */
  static  SET_CURUSERID='SET_USERID';
  /**
   * 设置当前授权token
   * @type {string}
   */
  static  SET_TOKEN='SET_TOKEN';
  /**
   * 设置当前用户角色
   * @type {string}
   */
  static  SET_CURROLES='SET_CURROLES';
  /**
   * 设置当前用户所属域权限
   * @type {string}
   */
  static  SET_CURWORKCENTER='SET_CURWORKCENTER';
  /**
   * 当前用户所属菜单权限
   * @type {string}
   */
  static  SET_CURMENU='SET_CURMENU';
  /**
   * 设置当前用户所属子权限
   * @type {string}
   */
  static  SET_CURPERMISSION='SET_CURPERMISSION';

  //公共模块
  /**
   * 修改菜单模块
   * @type {string}
   */
  static  SET_MENU='SET_MENU';
  /**
   * 设置记录总数
   * @type {string}
   */
  static  SET_TOTALCOUNT='SET_TOTALCOUNT';
  /**
   * 设置当前页
   * @type {string}
   */
  static SET_SKIPCOUNT='SET_SKIPCOUNT';
  /**
   * 设置当前页可选择的分页数目
   * @type {string}
   */
  static SET_MAXRESULTCOUNT='SET_MAXRESULTCOUNT';
  /**
   * 设置加载遮罩层是否显示
   * @type {string}
   */
  static  SET_LOADING='SET_LOADING';
  /**
   * 设置是否显示新增框
   * @type {string}
   */
  static  SET_AddFORMVISIBLE='SET_AddFORMVISIBLE';
  /**
   * 设置是否显示导入框
   * @type {string}
   */
  static  SET_IMPORTFORMVISIBLE='SET_IMPORTFORMVISIBLE';
  /**
   * 设置是否显示编辑框
   * @type {string}
   */
  static SET_EDITFORMVISIBLE='SET_EDITFORMVISIBLE';
  /**
   * 设置离散数据变量
  */
 static SET_EDITDISCRETE='SET_EDITDISCRETE';
  /**
   * 设置离散数据详情变量
  */
 static SET_EDITTASKBATCH='SET_EDITTASKBATCH';
  /**
   * 设置上传excel路径
   * @type {string}
   */
  static SET_UPLOADPATH='SET_UPLOADPATH';
    /**
   * 设置视觉数据变量
  */
 static SET_EDITAPPEARANCE='SET_EDITAPPEARANCE';
   /**
   * 设置测量数据汇总变量
  */
 static SET_EDITSUMMARY='SET_EDITSUMMARY';
 /**
   * 设置测量数据详情变量
  */
 static SET_EDITDIMENSIONDETAIL='SET_EDITDIMENSIONDETAIL';

 /*option*/
  /**
   * 产品
   * @type {string}
   */
 static ProductOptions='ProductOptions';
  /**
   * 设置设备
   * @type {string}
   */
 static EquipmentOptions='EquipmentOptions';
}
