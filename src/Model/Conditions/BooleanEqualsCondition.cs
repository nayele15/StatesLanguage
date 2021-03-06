/*
 * Copyright 2010-2017 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * Copyright 2018- Vincent DARON All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

using System;
using StatesLanguage.Model.Internal;
using StatesLanguage.Model.States;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StatesLanguage.Model.Conditions
{
    /// <summary>
    ///     Binary condition for Boolean equality comparison.
    ///     <see cref="Choice" />
    /// </summary>
    public sealed class BooleanEqualsCondition : IBinaryCondition<bool>
    {
        private BooleanEqualsCondition()
        {
        }

        [JsonProperty(PropertyNames.VARIABLE)]
        public string Variable { get; private set; }

        [JsonProperty(PropertyNames.BOOLEAN_EQUALS)]
        public bool ExpectedValue { get; private set; }

        /// <returns>Builder instance to construct a <see cref="BooleanEqualsCondition" /></returns>
        public static Builder GetBuilder()
        {
            return new Builder();
        }


        /// <summary>
        ///     Builder for a <see cref="BooleanEqualsCondition" />.
        /// </summary>
        public sealed class Builder : IBinaryConditionBuilder<Builder, BooleanEqualsCondition, bool>
        {
            private bool _expectedValue;
            private string _variable;

            internal Builder()
            {
            }

            public string Type => PropertyNames.BOOLEAN_EQUALS;

            /// <summary>
            ///     Sets the expected value for this condition.
            /// </summary>
            /// <param name="expectedValue">Expected value.</param>
            /// <returns> This object for method chaining.</returns>
            public Builder ExpectedValue(bool expectedValue)
            {
                _expectedValue = expectedValue;
                return this;
            }

            /// <returns>An immutable <see cref="BooleanEqualsCondition" /> object.</returns>
            public BooleanEqualsCondition Build()
            {
                return new BooleanEqualsCondition
                       {
                           Variable = _variable,
                           ExpectedValue = _expectedValue
                       };
            }

            /// <summary>
            ///     Sets the JSONPath expression that determines which piece of the input document is used for the comparison.
            /// </summary>
            /// <param name="variable">variable Reference path.</param>
            /// <returns>This object for method chaining.</returns>
            public Builder Variable(string variable)
            {
                _variable = variable;
                return this;
            }
        }

        public bool Match(JObject input)
        {
            try
            {
                return input.SelectToken(Variable)?.Value<bool>() == ExpectedValue;
            }
            catch (FormatException e)
            {
                return false;
            }
        }
    }
}