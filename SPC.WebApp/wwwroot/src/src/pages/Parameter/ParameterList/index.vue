<template>
  <el-row class="warp">
    <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="filter">
            <el-input v-model="filter.parameterKeyword" placeholder="参数编号或名称" @keyup.enter.native="search" size="mini"></el-input>
            <el-button type="primary" icon="el-icon-search" size="mini" @click="search" >搜索</el-button>
            <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right"  size="mini" @click="showAddDialog" >添加</el-button>
          </el-form>
        </div>
      </div>
      <!--列表-->
      <el-table class="tableCss" :data="datalist" highlight-current-row @selection-change="selectInfos" stripe
                style="width: 100%;">
        <el-table-column type="index" width="60">
        </el-table-column>
        <el-table-column prop="parameterCode" label="参数编号" sortable>
        </el-table-column>
        <el-table-column prop="parameterName" label="参数名称" sortable>
        </el-table-column>
        <el-table-column prop="parameterDataType" label="参数数据类型" sortable>
        </el-table-column>
        <el-table-column prop="parameterValuePrecision" label="参数值" sortable>
        </el-table-column>
        <el-table-column prop="parameterValueType" label="参数值类型" sortable>
        </el-table-column>
        <el-table-column prop="standardValue" label="标准值" sortable>
        </el-table-column>
        <el-table-column prop="minValue" label="最小值" sortable>
        </el-table-column>
        <el-table-column prop="maxValue" label="最大值" sortable>
        </el-table-column>
        <el-table-column label="操作" width="150">
          <template slot-scope="scope">
            <el-button size="small" @click="showEditDialog(scope.row)">编辑</el-button>
            <el-button type="danger" @click="del(scope.row.parameterID)" size="small">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
      <!--工具条-->
      <el-col :span="24" class="toolbar">
        <Pagination
          @handleCurrentChange="handleCurrentChange"
          @handleSizeChange="maxResultCountSelect"
          :page-size="maxResultCount"
          :page-sizes="pageSelectList"
          :total="totalCount">
        </Pagination>
      </el-col>
      <!--新增界面-->
      <el-dialog  :visible.sync ="addFormVisible"  :before-close="closeAddDialog">
        <div slot="title">添加参数</div>
        <el-form :model="addForm" label-width="130px" :rules="editFormRules" ref="addForm">
          <el-form-item label="参数编号:" prop="parameterCode">
            <el-input v-model="addForm.parameterCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="参数名称:" prop="parameterName">
            <el-input v-model="addForm.parameterName" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="参数数据类型:" prop="parameterDataType">
            <el-select v-model="addForm.parameterDataType"  placeholder="请选择">
              <el-option
                v-for="item in parameterDataTypeOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="参数值:" prop="parameterValuePrecision">
            <el-input type="number" v-model="addForm.parameterValuePrecision" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="参数值类型:"  prop="parameterValueType" size="small">
            <el-select v-model="addForm.parameterValueType"  placeholder="请选择">
              <el-option
                v-for="item in parameterValueTypeOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="标准值:" prop="standardValue">
            <el-input type="number" v-model="addForm.standardValue" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="最小值:" prop="minValue">
            <el-input type="number" v-model="addForm.minValue" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="最大值:" prop="maxValue">
            <el-input type="number" v-model="addForm.maxValue" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeAddDialog">取消</el-button>
          <el-button type="primary" @click.native="add" :loading="loading">保存</el-button>
        </div>
      </el-dialog>

      <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
        <div slot="title">编辑设备</div>
        <el-form :model="editForm" label-width="130px" :rules="editFormRules" ref="editForm">
          <el-form-item label="参数编号:" prop="parameterCode">
            <el-input v-model="editForm.parameterCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="参数名称:" prop="parameterName">
            <el-input v-model="editForm.parameterName" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="参数数据类型:" prop="parameterDataType">
            <el-select v-model="editForm.parameterDataType"  placeholder="请选择">
              <el-option
                v-for="item in parameterDataTypeOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="参数值:" prop="parameterValuePrecision">
            <el-input type="number" v-model="editForm.parameterValuePrecision" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="参数值类型:"  prop="parameterValueType" size="small">
            <el-select v-model="editForm.parameterValueType"  placeholder="请选择">
              <el-option
                v-for="item in parameterValueTypeOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="标准值:" prop="standardValue">
            <el-input type="number" v-model="editForm.standardValue" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="最小值:" prop="minValue">
            <el-input type="number" v-model="editForm.minValue" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="最大值:" prop="maxValue">
            <el-input type="number" v-model="editForm.maxValue" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeEditDialog">取消</el-button>
          <el-button type="primary" @click.native="edit">保存</el-button>
        </div>
      </el-dialog>
    </el-col>
  </el-row>
</template>
<script>
  import ParameterView from '../../../View/ParameterView';
  export default new ParameterView()
</script>
<style lang="stylus" scope>
  @import '../../../common/common.stylus'
</style>
