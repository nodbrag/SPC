<template>
    <!-- <div>
        <div class="box_table info" :data="TaskBatchList">
            <div class="header">
                <el-form  class="demo-form-inline">
                    <el-form-item><span style="font-size:15px;color:#666666;font-family:Avenir95-Black;font-weight:900;">{{TaskBatchList.batchNo}}</span>
                    <span style="font-size:12px;color:#9B9B9B;font-family:方正细黑一简体;">{{TaskBatchList.productName}}</span></el-form-item>
                </el-form>
            </div>
            <el-card class="box-card">
                <div slot="header" class="clearfix">
                    <span>物料信息</span>
                    <el-button type="text">删除</el-button>
                    <el-button type="text">编辑</el-button>
                </div>
                <div class="text item">
                    <el-form :model="inventoryList" :label-position="right" label-width="165px">
                        <el-form-item label="物料编码">{{inventoryList.inventoryCode}}</el-form-item>
                        <el-form-item label="物料名称">{{inventoryList.inventoryName}}</el-form-item>
                        <el-form-item label="规格">{{inventoryList.specification}}</el-form-item>
                        <el-form-item label="品质">{{inventoryList.quality}}</el-form-item>
                    </el-form>
                </div>
            </el-card>
            <el-card class="box-card">
                <div slot="header" class="clearfix">
                    <span>生产信息</span>
                    <el-button type="text">删除</el-button>
                    <el-button type="text">编辑</el-button>
                </div>
                <div class="text item">
                    <el-form :model="productList" :label-position="right" label-width="165px">
                        <el-row>
                            <el-col span="6"><el-form-item label="注射机编号">{{productList.injection}}</el-form-item></el-col>
                            <el-col span="6"><el-form-item label="生产数量">{{productList.quality}}</el-form-item></el-col>
                        </el-row>
                        <el-form-item label="模具编号">{{productList.moldnumber}}</el-form-item>
                        <el-form-item label="模穴号">{{productList.mouldpointnumber}}</el-form-item>
                        <el-form-item label="生产时间">{{productList.time}}</el-form-item>
                    </el-form>
                </div>
            </el-card>
            <el-card class="box-card">
                <div slot="header" class="clearfix">
                    <span>生产信息2</span>
                    <el-button type="text">删除</el-button>
                    <el-button type="text">编辑</el-button>
                </div>
                <div class="text item">
                    <el-form :model="productList2" :label-position="right" label-width="165px">
                        <el-row>
                            <el-col span="6"><el-form-item label="摆件机编号">{{productList2.pendulum}}</el-form-item></el-col>
                            <el-col span="6"><el-form-item label="生产数量">{{productList2.quality}}</el-form-item></el-col>
                        </el-row>
                        <el-form-item label="生产时间">{{productList2.time}}</el-form-item>
                    </el-form>
                </div>
            </el-card>
            <el-card class="box-card">
                <div slot="header" class="clearfix">
                    <span>生产信息3</span>
                    <el-button type="text">删除</el-button>
                    <el-button type="text">编辑</el-button>
                </div>
                <div class="text item">
                    <el-form :model="productList3" :label-position="right" label-width="165px">
                        <el-row>
                            <el-col span="6"><el-form-item label="烧结炉编号">{{productList3.Sinter}}</el-form-item></el-col>
                            <el-col span="6"><el-form-item label="生产数量">{{productList3.quality}}</el-form-item></el-col>
                        </el-row>
                        <el-form-item label="生产时间">{{productList3.time}}</el-form-item>
                    </el-form>
                </div>
            </el-card>
            <el-card class="box-card">
                <div slot="header" class="clearfix">
                    <span>生产信息4</span>
                    <el-button type="text">删除</el-button>
                    <el-button type="text">编辑</el-button>
                </div>
                <div class="text item">
                    <el-form :model="productList4" :label-position="right" label-width="165px">
                        <el-row>
                            <el-col span="6"><el-form-item label="整形机编号">{{productList4.Shap}}</el-form-item></el-col>
                            <el-col span="6"><el-form-item label="生产数量">{{productList4.quality}}</el-form-item></el-col>
                        </el-row>
                        <el-form-item label="生产时间">{{productList4.time}}</el-form-item>
                    </el-form>
                </div>
            </el-card>
        </div>
        
    </div> -->
    <el-row class="warp">
        <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
            <div v-for="item of TaskBatchList">
                <el-card class="box-card">
                    <div slot="header" class="clearfix">
                        <span>{{item.productName}}---{{item.workProcessName}}</span>
                        <el-button type="text" size="small" @click="showEditDialog(item)">编辑</el-button>
                    </div>
                    <div class="text item">
                        <el-form label-width="165px">
                            <el-form-item label="设备名称">{{item.equipmentName}}</el-form-item>
                            <el-form-item label="时间">{{item.beginDateTime}}</el-form-item><!--/{{item.endDateTime}}-->
                            <el-form-item label="数量">{{item.quantity}}</el-form-item>
                            <el-form-item label="模具号" v-if="item.workProcessName === '注射'">{{item.userDefine1}}</el-form-item>
                            <el-form-item label="模穴号" v-if="item.workProcessName === '注射'">{{item.userDefine2}}</el-form-item>
                        </el-form>
                    </div>
                </el-card>
            </div>
        </el-col>
        <!--编辑-->
        <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
            <div slot="title">编辑{{editForm.workProcessName}}</div>
            <el-form :model="editForm" label-width="130px" :rules="editFormRules" ref="editForm">
            <el-form-item label="设备:" prop="equipmentClassId">
                <el-select v-model="editForm.equipmentId"  placeholder="请选择">
                <el-option
                    v-for="item in equipmentOptions"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                </el-option>
                </el-select>
            </el-form-item>
            <el-form-item label="时间:" prop="beginDateTime">
                <el-date-picker v-model="editForm.beginDateTime" placeholder="开始时间" value-format="yyyy-MM-dd"></el-date-picker>
            </el-form-item>
            <el-form-item label="数量:"  prop="quantity" size="small">
                <el-input v-model="editForm.quantity" auto-complete="off" type="number"></el-input>
            </el-form-item>
            <el-form-item label="模具编号:" prop="userDefine1" v-if="editForm.workProcessName == '注射'">
                <el-input v-model="editForm.userDefine1" auto-complete="off"></el-input>
            </el-form-item>
            <el-form-item label="模穴编号:" prop="userDefine2" v-if="editForm.workProcessName == '注射'">
                <el-input v-model="editForm.userDefine2" auto-complete="off"></el-input>
            </el-form-item>
            </el-form>
            <div slot="footer" class="dialog-footer">
            <el-button @click.native="closeEditDialog">取消</el-button>
            <el-button type="primary" @click.native="editTaskBatch">保存</el-button>
            </div>
        </el-dialog>
    </el-row>
</template>
<script>
    import DiscreteInfoView from '../../../View/DiscreteInfoView';
    export default new DiscreteInfoView()
</script>

<style>
    .info .header .el-form-item,.el-card .el-form-item{
        margin-bottom:0px
    }
    .info .header .el-form-item__content{
        line-height: 26px;
        height: 26px
    }
    .info .header .el-button--primary.is-plain {
        color: #2673FF;
        background: #fff;
        border-color: #1E6EFF;
    }
    .info .header{
        margin-bottom:12px
    }
    .el-card.is-always-shadow, .el-card.is-hover-shadow:focus, .el-card.is-hover-shadow:hover{
        box-shadow: none
    }
    .el-card{
        border:1px solid #E0E0E0;
        margin-bottom:20px;
    }
    .el-card__header{
        font-family: 方正大黑简体;
        font-size: 12px;
        color: #666666;
        border-bottom: none;
        padding: 11px 12px;
        background: #EDF1FF;
    }
    .el-card__header .el-button--text{
        float: right; 
        padding: 0px 4px;
        font-size: 12px; 
        color: rgb(102, 102, 102); 
        font-family: 方正细黑一简体;
    }
    .el-card .el-form-item__label{
        padding-right:40px;
        line-height: 24px;
        height: 24px;    
        font-family: 方正细黑一简体;
        color: #9B9B9B;
        font-size: 12px
    }
    .el-card .el-form-item__content{
        line-height: 24px;
        height: 24px;
        font-family: 方正黑体简体;
        color: #62666C;
        font-size: 12px
    }
    .el-card__body{
        padding:10px 0 23px 0
    }
</style>
